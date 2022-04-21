using Animals.Core.Exceptions;
using Animals.Core.FileParsers;
using Animals.Core.Interfaces;
using System.Collections.Generic;
using Animals.Core.Constants;

namespace Animals.Console.Services
{
	class ConsoleAnimalParserService : IAnimalParser
	{
        private readonly Dictionary<string, IFromFileParser> _dict;
		public ConsoleAnimalParserService()
		{
			_dict = new Dictionary<string, IFromFileParser>()
			{
				{"Cat", new CatParser(ConsoleSoundService.CreateSoundService(Consts.GetCatSound)) },
				{"Dog", new DogParser(ConsoleSoundService.CreateSoundService(Consts.GetDogSound)) },
				{"Chicken", new ChickenParser(ConsoleSoundService.CreateSoundService(Consts.GetChickenSound)) },
				{"Stork", new StorkParser(ConsoleSoundService.CreateSoundService(Consts.GetStorkSound)) },
				{"Tiger", new TigerParser(ConsoleSoundService.CreateSoundService(Consts.GetTigerSound)) },
				{"Wolf", new WolfParser(ConsoleSoundService.CreateSoundService(Consts.GetWolfSound)) }
			};
		}

		public IAnimal Parse(List<string> animals)
		{
			IAnimal animal;
			if (_dict.ContainsKey(animals[0]))
				animal = _dict[animals[0]].Parse(animals);
			else
				throw new IncorrectActionException("There is no animal like this.");
			return animal;
		}
	}
}
