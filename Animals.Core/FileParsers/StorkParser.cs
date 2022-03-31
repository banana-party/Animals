using Animals.Core.Business.Instances;
using Animals.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace Animals.Core.FileParsers
{
    public class StorkParser : BaseParser, IFromFileParser
	{
        public StorkParser(IMakeASoundable aSound) : base(aSound)
        {
        }
		public IAnimal Parse(List<string> lst)
		{
            //TODO: Необходимо сделать проверку на то, что коллекция не null и параметров достаточно, а так же float.Parse может приводить к исключению
			return new Stork(
				float.Parse(lst[1], CultureInfo.InvariantCulture), 
				float.Parse(lst[2], CultureInfo.InvariantCulture), 
				lst[3], 
				int.Parse(lst[4]), 
				_aSound);
		}

	}
}
