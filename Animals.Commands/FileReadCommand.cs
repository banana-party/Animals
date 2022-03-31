using Animals.Commands.Bases;
using Animals.Core.Business;
using Animals.Core.Interfaces;
using System;
using System.IO;

namespace Animals.Commands
{
	public class FileReadCommand : NotificationAndReaderCommandBase
	{
        private readonly IFileReader _fileReader;
		public FileReadCommand(Zoo zoo, INotificationService notificationService, IReaderService readerService, IFileReader fileReader) : base(zoo, notificationService, readerService)
		{
			_fileReader = fileReader;
		}

		public override void Execute()
		{
			NotificationService.Write("Введите путь к файлу (пустая строка означает путь по умолчанию): \n");
			string text = ReaderService.ReadLine();
			if (string.IsNullOrEmpty(text))
				text = "Input.txt";
			try
			{
				//Лучше использовать ?.
				Zoo.AddRange(_fileReader?.Read(text));
			}
			//Не все виды ошибок перехвачены, возможны падения программы
			catch (IOException)
			{
				NotificationService.Write("File or directory does not exist.");
			}

		}
		//Метод можно было прочитать лучше
		public override string ToString()
		{
			return "Прочитать зоопарк из файла.";
		}
	}
}
