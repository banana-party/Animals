using Animals.Core.Business.Bases;
using Animals.Core.Interfaces;
using System;
//Хорошо всё
namespace Animals.Core.Business.Instances
{
	public class Dog : HomeAnimalBase
	{
		public bool IsItTrained { get; private set; }
		public Dog(float height, float weight, string eyeColor, string name, string breed, bool isItVaccinated, string coatColor, DateTime birthDate, bool isItTrained, IMakeASoundable aSound) 
			: base(height, weight, eyeColor, name, breed, isItVaccinated, coatColor, birthDate, aSound)
		{
			IsItTrained = isItTrained;
		}
		public void Train()
		{
			if (IsItTrained)
				return;
			IsItTrained = true;
		}
		//метод можно было реализовать лучше
		public override void MakeASound()
		{
			ASound.MakeASound();
		}
		//метод можно было реализовать лучше
		public override string ToString()
		{
			return $"{base.ToString()},{IsItTrained}";
		}
	}
}
