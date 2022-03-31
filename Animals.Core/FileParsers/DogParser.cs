using Animals.Core.Business.Instances;
using Animals.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace Animals.Core.FileParsers
{
	public class DogParser : BaseParser, IFromFileParser
	{
        public DogParser(IMakeASoundable aSound) : base(aSound)
        {
        }
		public IAnimal Parse(List<string> lst)
		{
            //TODO: Необходима проверка на то, что достаточно параметров и коллекция не null, а так же float.Parse может приводить к исключениям
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
