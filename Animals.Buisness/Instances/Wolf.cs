using Animals.Bases;
using System;

namespace Animals.Buisness.Instances
{
	public class Wolf : WildAnimalBase
	{
		public bool IsItAlpha { get; }
		public Wolf(bool isItAlpha, float height, float weight, string eyeColor, string habitat, DateTime dateOfFind) : base(height, weight, eyeColor, habitat, dateOfFind)
		{
			IsItAlpha = isItAlpha;
		}
		public override void MakeASound()
		{
			//TODO реализовать метод
		}
		public override void PrintInfo()
		{
			base.PrintInfo();
			//TODO реализовать часть с альфа волком
		}
	}

}
