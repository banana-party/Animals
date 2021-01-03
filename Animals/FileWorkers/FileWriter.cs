using Animals.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;

namespace Animals.Console.FileWorkers
{
	public class FileWriter : IFileWriter, IDisposable
	{
		private StreamWriter _streamWriter;
		public FileWriter()
		{
			_streamWriter = new StreamWriter("Output.txt");
		}

		public void Dispose()
		{
			_streamWriter.Dispose();
		}

		public void WriteToFile(IEnumerable<string> animals)
		{
			foreach (var el in animals)
				_streamWriter.WriteLine(el);
			_streamWriter.Dispose();
		}
	}
}
