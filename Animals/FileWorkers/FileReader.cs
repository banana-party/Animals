using Animals.Core.FileParsers;
using Animals.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Animals.Console.FileWorkers
{
	class FileReader : IFileReader, IDisposable
	{
		private StreamReader _stream;
		private Dictionary<string, IFromFileParser> _dict;
		private readonly IAnimalParser _animalParser; // TODO: IAnimalParser или IFromFileParser? Парсеры одинаковые, есть ли смысл разделять интерфейсы?
		public FileReader(IAnimalParser animalParser)
		{
			_animalParser = animalParser;
		}

		public void Dispose()
		{
			_stream.Dispose();
		}

		public IEnumerable<IAnimal> Read(string path)
		{
			if (string.IsNullOrEmpty(path))
				throw new NullReferenceException("String was null or empty");
			_stream = new StreamReader(path);
			List<IAnimal> animals = new List<IAnimal>();
			while (!_stream.EndOfStream)
			{
				var txt = _stream.ReadLine();
				List<string> lst = txt.Split(',').ToList();
				animals.Add(_animalParser.Parse(lst));
			}
			Dispose();
			return animals;
		}
	}
}
