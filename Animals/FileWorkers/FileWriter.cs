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
            //Те же самые ошибки, что и в StreamReader
			//Необходимо проверять коллекцию на то, что в ней есть элементы иначе возможно исключение
			foreach (var el in animals)
				_streamWriter.WriteLine(el);
			_streamWriter.Dispose();
		}
	}
}
