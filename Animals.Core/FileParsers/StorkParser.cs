﻿using Animals.Core.Business.Instances;
using Animals.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace Animals.Core.FileParsers
{
    public class StorkParser : BaseParser, IFromFileParser
	{
        public StorkParser(IMakeASoundable aSound, IDialogService dialog) : base(aSound, dialog)
        {
        }
		public IAnimal Parse(IEnumerable<string> lst)
		{
            //TODO: Необходимо сделать проверку на то, что коллекция не null и параметров достаточно, а так же float.Parse может приводить к исключению
            return new Stork(ASound, DialogService);
        }

	}
}
