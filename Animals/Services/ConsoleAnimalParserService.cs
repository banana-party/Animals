using Animals.Core.Exceptions;
using Animals.Core.FileParsers;
using Animals.Core.Interfaces;
using System.Collections.Generic;
using Animals.Console.Constants;

namespace Animals.Console.Services
{
	class ConsoleAnimalParserService : IAnimalParser
	{
        private readonly Dictionary<string, IFromFileParser> _dict;
		public ConsoleAnimalParserService()
		{
			_dict = new Dictionary<string, IFromFileParser>()
			{
				{"Cat", new CatParser(ConsoleSoundService.CreateSoundService(Consts.CAT_SOUND)) },
				{"Dog", new DogParser(ConsoleSoundService.CreateSoundService(Consts.DOG_SOUND)) },
				{"Chicken", new ChickenParser(ConsoleSoundService.CreateSoundService(Consts.CHICKEN_SOUND)) },
				{"Stork", new StorkParser(ConsoleSoundService.CreateSoundService(Consts.STORK_SOUND)) },
				{"Tiger", new TigerParser(ConsoleSoundService.CreateSoundService(Consts.TIGER_SOUND)) },
				{"Wolf", new WolfParser(ConsoleSoundService.CreateSoundService(Consts.WOLF_SOUND)) }
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
