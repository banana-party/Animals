using Animals.Core.Exceptions;
using Animals.Core.FileParsers;
using Animals.Core.Interfaces;
using System.Collections.Generic;
using System.Linq;
using Animals.Core.Constants;

namespace Animals.Console.Services
{
	class ConsoleAnimalParserService : IAnimalParser
	{
        private readonly Dictionary<string, IFromFileParser> _dict;
		public ConsoleAnimalParserService(IDialogService dialog)
		{
			_dict = new Dictionary<string, IFromFileParser>()
			{
				{"Cat", new CatParser(ConsoleSoundService.CreateSoundService(Consts.GetCatSound), dialog) },
				{"Dog", new DogParser(ConsoleSoundService.CreateSoundService(Consts.GetDogSound), dialog) },
				{"Chicken", new ChickenParser(ConsoleSoundService.CreateSoundService(Consts.GetChickenSound), dialog) },
				{"Stork", new StorkParser(ConsoleSoundService.CreateSoundService(Consts.GetStorkSound), dialog) },
				{"Tiger", new TigerParser(ConsoleSoundService.CreateSoundService(Consts.GetTigerSound), dialog) },
				{"Wolf", new WolfParser(ConsoleSoundService.CreateSoundService(Consts.GetWolfSound), dialog) }
			};
		}

		public IAnimal Parse(IEnumerable<string> animals)
		{
			IAnimal animal;
			if (_dict.ContainsKey(animals.First()))
				animal = _dict[animals.First()].Parse(animals);
			else
				throw new IncorrectActionException("There is no animal like this.");
			return animal;
		}
	}
}
