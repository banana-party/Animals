using Animals.Bases;
using Animals.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Animals.Instances
{
	class Chicken : BaseBird
	{
		public Chicken(ISoundable soundable, IFlyable flyable) : base(soundable, flyable)
		{
		}
	}
}
