using Animals.Core.Business.Bases;
using Animals.Core.Interfaces;
using System;
//отлично всё
namespace Animals.Core.Business.Instances
{
	public class Cat : HomeAnimalBase
	{

		public Cat(float height, float weight, string eyeColor, string name, string breed, bool isItVaccinated, string coatColor, DateTime birthDate, bool isItWooled, IMakeASoundable aSound) 
			: base(height, weight, eyeColor, name, breed, isItVaccinated, coatColor, birthDate, aSound)
		{
			IsItWooled = isItWooled;
		}
		public bool IsItWooled { get; }

		public override void MakeASound()
		{
			ASound.MakeASound();
		}

		public override string ToString()
		{
			return $"{base.ToString()},{IsItWooled}";
		}

	}
}
