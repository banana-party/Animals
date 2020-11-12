using Animals.Core.Business.Instances;
using Animals.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Animals.Core.FileParsers
{
	public class TigerParser : IFromFileParser
	{
		private readonly IMakeASoundable _aSound;
		public TigerParser(IMakeASoundable aSound)
		{
			_aSound = aSound;
		}
		public IAnimal Parse(List<string> lst)
		{
			return new Tiger(
				float.Parse(lst[1], CultureInfo.InvariantCulture), 
				float.Parse(lst[2], CultureInfo.InvariantCulture), 
				lst[3], 
				lst[4], 
				DateTime.Parse(lst[5]), 
				_aSound);
		}
	}
}
