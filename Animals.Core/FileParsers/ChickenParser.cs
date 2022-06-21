using Animals.Core.Business.Instances;
using Animals.Core.Interfaces;
using System.Collections.Generic;
using System.Globalization;

namespace Animals.Core.FileParsers
{
    public class ChickenParser :BaseParser, IFromFileParser
	{
        public ChickenParser(IMakeASoundable aSound, IDialogService dialog) : base(aSound, dialog)
        {
        }
		public IAnimal Parse(IEnumerable<string> lst)
		{
            //TODO: Необходимо сделать проверки на то, что коллекция не пуста и не null и параметров достаточно, Так же возможны исключения в float.Parse
			return new Chicken(ASound, DialogService);
		}
	}
}
