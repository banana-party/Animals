using Animals.Bases;
using System;

namespace Animals.Instances
{
	class Cat : HomeAnimalBase
	{

		public Cat(bool isItWooled, float height, float weight, string eyeColor, string name, string breed, bool isItVaccinated, string coatColor, DateTime birthDate) : base(height, weight, eyeColor, name, breed, isItVaccinated, coatColor, birthDate)
		{
			IsItWooled = isItWooled;
		}
		public bool IsItWooled { get; }

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
			//TODO реализовать вывод о параметре с шерстью.
		}

	}
}
