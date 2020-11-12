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

		public FileReader(IMakeASoundable aSound)
		{
			_dict = new Dictionary<string, IFromFileParser>()
			{
				{"Cat", new CatParser(aSound) },
				{"Dog", new DogParser(aSound) },
				{"Chicken", new ChickenParser(aSound) },
				{"Stork", new StorkParser(aSound) },
				{"Tiger", new TigerParser(aSound) },
				{"Wolf", new WolfParser(aSound) }
			};
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
				if (_dict.ContainsKey(lst[0]))
					animals.Add(_dict[lst[0]].Parse(lst));
			}
			return animals;
		}
	}
}
