using Animals.Core.Business.Instances;
using Animals.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace Animals.Core.FileParsers
{
    public class CatParser : IFromFileParser
	{
		private readonly IMakeASoundable _aSound;
		//Надо подумать как избавиться от этих параметрах в парсере, они тут нелогичны абсолютно
		//но никакого разумного решения этого я тут предложить не смогу.
        public CatParser(IMakeASoundable aSound)
		{
			_aSound = aSound;
		}
		public IAnimal Parse(List<string> lst)
		{
			return new Cat(
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
