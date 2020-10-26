using Animals.Bases;
using Animals.Core.Interfaces;
using System;

namespace Animals.Instances
{
	class Dog : HomeAnimalBase
	{
		public bool IsItTrained { get; private set; }
		public Dog(bool isItTrained, float height, float weight, string eyeColor, string name, string breed, bool isItVaccinated, string coatColor, DateTime birthDate) : base(height, weight, eyeColor, name, breed, isItVaccinated, coatColor, birthDate)
		{
			IsItTrained = isItTrained;
		}
		public void Train()
		{
			//TODO Реализовать метод
		}

		public override void Care()
		{
			//TODO Реализовать метод
		}

		public override void MakeASound()
		{
			//TODO Реализовать метод
		}

		public override void PrintInfo()
		{
			base.PrintInfo();
			//TODO реализовать вывод о параметре с тренировкой
		}


	}
}
