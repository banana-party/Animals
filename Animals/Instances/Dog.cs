using Animals.Bases;
using Animals.Core.Interfaces;
using System;

namespace Animals.Instances
{
	class Dog : BaseHomeAnimal
	{
		private ITraineble _traineble;
		public bool IsItTrained { get; set; }
		public Dog(bool isItWooled, float height, float weight, string eyeColor, string name, string breed, bool isItVaccinated, string coatColor, DateTime birthDate, ITraineble traineble) : base(height, weight, eyeColor, name, breed, isItVaccinated, coatColor, birthDate)
		{
			_traineble = traineble;
		}
		public void Train()
		{
			_traineble.Train();
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
			//TODO реализовать вывод о параметре с шерстью.
		}


	}
}
