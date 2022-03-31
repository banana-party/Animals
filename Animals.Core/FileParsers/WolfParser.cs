using Animals.Core.Business.Instances;
using Animals.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace Animals.Core.FileParsers
{
	public class WolfParser : BaseParser, IFromFileParser
	{
        public WolfParser(IMakeASoundable aSound) : base(aSound)
        {
        }
		public IAnimal Parse(List<string> lst)
		{
			//TODO: Необходимо сделать проверку что параметров достаточно и float.Parse может приводить к исключению
            if (lst is null)
                throw new NullReferenceException();
            try
            {
                return new Wolf( 
                    float.Parse(lst[1], CultureInfo.InvariantCulture), 
                    float.Parse(lst[2], CultureInfo.InvariantCulture),
                    lst[3], lst[4], 
                    DateTime.Parse(lst[5]),
                    bool.Parse(lst[6]),
                    _aSound
                );
            }
            catch (FormatException e)
            {
                Console.WriteLine(e);
                throw;
            }

		}
	}
}
