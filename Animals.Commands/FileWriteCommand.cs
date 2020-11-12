using Animals.Commands.Bases;
using Animals.Core.Business;
using Animals.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Animals.Commands
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
			_fileWriter.WriteToFile(Zoo.Info());
		}
		public override string ToString()
		{
			return "Сохранить зоопарк в файл.";
		}
	}
}
