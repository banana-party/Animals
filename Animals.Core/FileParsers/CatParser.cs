using Animals.Core.Business.Instances;
using Animals.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace Animals.Core.FileParsers
{
    public class CatParser : BaseParser, IFromFileParser
    {
        public CatParser(IMakeASoundable aSound, IDialogService dialog) : base(aSound, dialog)
        {
        }
        public IAnimal Parse(List<string> lst)
		{
            //TODO: Нужно сделать проверку на то, что параметров достаточно и коллекция не пуста и не null
			return new Cat(ASound, DialogService);
		}

	}
}
