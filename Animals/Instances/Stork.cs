using Animals.Bases;
using Animals.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Animals.Instances
{
	class Stork : BirdBase
	{
		public Stork(float height, float weight, string eyeColor, int flyHeight) : base(height, weight, eyeColor, flyHeight)
		{
		}

		public override void MakeASound()
		{
			//TODO реализовать метод
		}
	}
}
