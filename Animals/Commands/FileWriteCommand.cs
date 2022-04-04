using Animals.Console.Commands.Bases;
using Animals.Core.Business;
using Animals.Core.Interfaces;

namespace Animals.Console.Commands
{
    public class FileWriteCommand : CommandBase
	{
		private readonly IFileWriter _fileWriter;
		public FileWriteCommand(Zoo zoo, IFileWriter fileWriter) : base(zoo)
		{
			_fileWriter = fileWriter;
		}

		public override void Execute()
		{
			//Лучше использовать ?.
			_fileWriter.WriteToFile(Zoo.Info());
		}
		//Метод можно было реализовать лучше
		public override string ToString()
		{
			return "Сохранить зоопарк в файл.";
		}
	}
}
