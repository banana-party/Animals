using Animals.Core.Business.Instances;
using Animals.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace Animals.Core.FileParsers
{
	public class TigerParser : BaseParser, IFromFileParser
	{
        public TigerParser(IMakeASoundable aSound, IDialogService dialog) : base(aSound, dialog)
        {
        }
		public IAnimal Parse(List<string> lst)
		{
            //TODO: Необходимо сделать проверку на то, что параметров достаточно и коллекция не null, а так же float.Parse может приводить к исключению
			return new Tiger(ASound, DialogService);
		}
	}
}
