using Animals.Bases;
using Animals.Core.Interfaces;
using System;

namespace Animals.Buisness.Instances
{
	public class Cat : HomeAnimalBase
	{

		public Cat(INotificationService notificationService, bool isItWooled, float height, float weight, string eyeColor, string name, string breed, bool isItVaccinated, string coatColor, DateTime birthDate) : base(notificationService, height, weight, eyeColor, name, breed, isItVaccinated, coatColor, birthDate)
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
			NotificationService.WriteLine($"\tШерсть {(IsItWooled ? "есть" : "отсутствует")}");
		}

	}
}
