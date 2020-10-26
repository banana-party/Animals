using Animals.Bases;
using System;

namespace Animals.Buisness.Instances
{
	public class Tiger : WildAnimalBase
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
