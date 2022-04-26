using Animals.Core.Business.Instances;
using Animals.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace Animals.Core.FileParsers
{
	public class DogParser : BaseParser, IFromFileParser
	{
        public DogParser(IMakeASoundable aSound, IDialogService dialog) : base(aSound, dialog)
        {
        }
		public IAnimal Parse(List<string> lst)
		{
            //TODO: Необходима проверка на то, что достаточно параметров и коллекция не null, а так же float.Parse может приводить к исключениям
			return new Dog(ASound, DialogService);
		}

	}
}
