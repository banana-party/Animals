using Animals.Core.Business.Instances;
using Animals.Core.Interfaces;
using System.Collections.Generic;
using System.Globalization;

namespace Animals.Core.FileParsers
{
    public class ChickenParser :BaseParser, IFromFileParser
	{
        public ChickenParser(IMakeASoundable aSound) : base(aSound)
        {
        }
		public IAnimal Parse(List<string> lst)
		{
            //TODO: Необходимо сделать проверки на то, что коллекция не пуста и не null и параметров достаточно, Так же возможны исключения в float.Parse
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
