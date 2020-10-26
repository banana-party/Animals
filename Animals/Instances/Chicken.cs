using Animals.Bases;
using Animals.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Animals.Instances
{
	class Chicken : BirdBase
	{
		public Chicken(float height, float weight, string eyeColor, int flyheight, IFlyable flyable) : base(height, weight, eyeColor, flyheight, flyable)
		{
		}

		public override void MakeASound()
		{
			//TODO реализовать метод
		}
	}
}
