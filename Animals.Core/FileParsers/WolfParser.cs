using Animals.Core.Business.Instances;
using Animals.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace Animals.Core.FileParsers
{
	public class WolfParser : IFromFileParser
	{
		private readonly IMakeASoundable _aSound;
		//Дублирование кода конструтора
		public WolfParser(IMakeASoundable aSound)
		{
			_aSound = aSound;
		}
		public IAnimal Parse(List<string> lst)
		{
			//Необходимо сделать проверку, что коллекция не null, а так же что параметров достаточно и
			//float.Parse может приводить к исключению
			return new Wolf( 
				float.Parse(lst[1], CultureInfo.InvariantCulture), 
				float.Parse(lst[2], CultureInfo.InvariantCulture),
				lst[3], lst[4], 
				DateTime.Parse(lst[5]),
				bool.Parse(lst[6]),
				_aSound
				);
		}
	}
}
