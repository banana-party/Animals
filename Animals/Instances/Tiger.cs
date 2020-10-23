using Animals.Bases;
using Animals.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Animals.Instances
{
	class Tiger : BaseWildAnimal
	{
		public Tiger(float height, float weight, string eyeColor, string habitat, DateTime dateOfFind) : base(height, weight, eyeColor, habitat, dateOfFind)
		{
		}
		public override void MakeASound()
		{
			//TODO реализовать метод
		}
	}
}
