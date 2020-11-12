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
		IFileWriter _fileWriter;
		public FileWriteCommand(Zoo zoo, IFileWriter fileWriter) : base(zoo)
		{
			_fileWriter = fileWriter;
		}

		public override void Execute()
		{
			_fileWriter.WriteToFile(Zoo.Info());
		}
	}
}
