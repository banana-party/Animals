using Animals.Bases;
using Animals.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Animals.Instances
{
	class Tiger : BaseWildAnimal
	{
		public Tiger(ISoundable soundable) : base(soundable)
		{
		}
	}
}
