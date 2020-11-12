using Animals.Core.Business.Instances;
using Animals.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace Animals.Core.FileParsers
{
	public class ChickenParser : IFromFileParser
	{
		private readonly IMakeASoundable _aSound;
		public ChickenParser(IMakeASoundable aSound)
		{
			_aSound = aSound;
		}
		public IAnimal Parse(List<string> lst)
		{
			return new Chicken(
				float.Parse(lst[1], CultureInfo.InvariantCulture), 
				float.Parse(lst[2], CultureInfo.InvariantCulture), 
				lst[3], 
				int.Parse(lst[4]), 
				_aSound
				);
		}
	}
}
