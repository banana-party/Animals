using Animals.Core.Business.Instances;
using Animals.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
//Дублирование кода конструктора
namespace Animals.Core.FileParsers
{
	public class DogParser : IFromFileParser
	{
		private readonly IMakeASoundable _aSound;
		public DogParser(IMakeASoundable aSound)
		{
			_aSound = aSound;

		}
		public IAnimal Parse(List<string> lst)
		{
			//Необходима проверка на то, что достаточно параметров и коллекция не null, а так же float.Parse может
			//приводить к исключениям
			return new Dog(
				float.Parse(lst[1], CultureInfo.InvariantCulture),
				float.Parse(lst[2], CultureInfo.InvariantCulture),
				lst[3],
				lst[4], lst[5],
				bool.Parse(lst[6]),
				lst[7],
				DateTime.Parse(lst[8]),
				bool.Parse(lst[9]),
				_aSound
				);
		}

	}
}
