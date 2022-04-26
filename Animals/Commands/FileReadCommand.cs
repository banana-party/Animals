using System.IO;
using Animals.Console.Commands.Bases;
using Animals.Core.Business;
using Animals.Core.Interfaces;

namespace Animals.Console.Commands
{
	public class FileReadCommand : DialogAndReaderCommandBase
	{
        private readonly IFileReader _fileReader;
		public FileReadCommand(Zoo zoo, IDialogService dialog, IReaderService readerService, IFileReader fileReader) : base(zoo, dialog, readerService)
		{
			_fileReader = fileReader;
		}

		public override void Execute()
		{
			DialogService.ShowMessage("Введите путь к файлу (пустая строка означает путь по умолчанию): \n");
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
                DialogService.ShowMessage("File or directory does not exist.");
			}

		}
		//Метод можно было прочитать лучше
		public override string ToString()
		{
			return "Прочитать зоопарк из файла.";
		}
	}
}
