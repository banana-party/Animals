using Animals.Core.Business.Instances;
using Animals.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace Animals.Core.FileParsers
{
	public class WolfParser : BaseParser, IFromFileParser
	{
        public WolfParser(IMakeASoundable aSound, IDialogService dialog) : base(aSound, dialog)
        {
        }
		public IAnimal Parse(List<string> lst)
		{
			//TODO: Необходимо сделать проверку что параметров достаточно и float.Parse может приводить к исключению
            if (lst is null)
                throw new NullReferenceException();
            try
            {
                return new Wolf(ASound, DialogService);
            }
            catch (FormatException e)
            {
                Console.WriteLine(e);
                throw;
            }

		}
	}
}
