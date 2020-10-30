using Animals.Core.FileParsers;
using Animals.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Animals.FileReaders
{
	class FileReader : IFileReader, IDisposable
	{
		private StreamReader _stream;
		private Dictionary<string, IParser> _dict;

		public FileReader(IMakeASoundable aSound, INotificationService notificationService)
		{
			_dict = new Dictionary<string, IParser>()
			{
				{"Cat", new CatParser(aSound, notificationService) },
				{"Dog", new DogParser(aSound, notificationService) },
				{"Chicken", new ChickenParser(aSound, notificationService) },
				{"Stork", new StorkParser(aSound, notificationService) },
				{"Tiger", new TigerParser(aSound, notificationService) },
				{"Wolf", new WolfParser(aSound, notificationService) }
			};
		}

		public void Dispose()
		{
			_stream.Dispose();
		}
		public bool Open(string path)
		{
			_stream = new StreamReader(path);
			if (_stream == null)
				return false;
			return true;
		}

		public IEnumerable<IAnimal> Read()
		{
			List<IAnimal> animals = new List<IAnimal>();
			while (!_stream.EndOfStream)
			{
				var txt = _stream.ReadLine();
				List<string> lst = txt.Split(',').ToList();
				if (_dict.ContainsKey(lst[0]))
				{
					animals.Add(_dict[lst[0]].Parse(lst));
				}
			}
			return animals;
		}
	}
}
