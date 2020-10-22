using Animals.Bases;
using Animals.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Animals.Instances
{
	class Stork : BaseBird
	{
		public Stork(ISoundable soundable, IFlyable flyable) : base(soundable, flyable)
		{
		}
	}
}
