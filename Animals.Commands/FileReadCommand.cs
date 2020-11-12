using Animals.Commands.Bases;
using Animals.Core.Business;
using Animals.Core.Interfaces;
using System;
using System.IO;

namespace Animals.Commands
{
    public class FileReadCommand : NotificationAndReaderCommandBase
	{
		private IFileReader _fileReader;
		public FileReadCommand(Zoo zoo, INotificationService notificationService, IReaderService readerService, IFileReader fileReader) : base(zoo, notificationService, readerService)
		{
			_fileReader = fileReader;
		}

		public override void Execute()
		{
			NotificationService.Write("Введите путь к файлу (пустая строка означает путь по умолчанию): \n");
			string text = ReaderService.ReadLine();
			if (string.IsNullOrEmpty(text))
				Zoo.Add(_fileReader.Read("Input.txt"));
			else
			{
				try
				{
					Zoo.Add(_fileReader.Read(text));
				}
				catch (IOException)
				{
					NotificationService.Write("File or directory does not exist.");
				}
			}
		}
		public override string ToString()
		{
			return "Прочитать зоопарк из файла.";
		}
	}
}
