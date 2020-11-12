﻿using Animals.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;

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
				_streamWriter.Write($"{el}\n");
		}
	}
}
