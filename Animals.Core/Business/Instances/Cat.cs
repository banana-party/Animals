using Animals.Core.Business.Bases;
using Animals.Core.Interfaces;
using System;

namespace Animals.Core.Business.Instances
{
	public class Cat : HomeAnimalBase
	{

		public Cat(IMakeASoundable aSound, INotificationService notificationService, bool isItWooled, float height, float weight, string eyeColor, string name, string breed, bool isItVaccinated, string coatColor, DateTime birthDate) : base(aSound, notificationService, height, weight, eyeColor, name, breed, isItVaccinated, coatColor, birthDate)
		{
			IsItWooled = isItWooled;
		}
		public bool IsItWooled { get; }

		public override void MakeASound()
		{
			ASound.MakeASound("МЯЯЯЯУ");
		}

		public override void PrintInfo()
		{
			base.PrintInfo();
			NotificationService.WriteLine($"\tШерсть {(IsItWooled ? "есть" : "отсутствует")}");
		}

	}
}
