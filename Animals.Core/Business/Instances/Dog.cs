using Animals.Core.Business.Bases;
using Animals.Core.Interfaces;
using System;

namespace Animals.Core.Business.Instances
{
	public class Dog : HomeAnimalBase
	{
		public bool IsItTrained { get; private set; }
		public Dog(INotificationService notificationService, bool isItTrained, float height, float weight, string eyeColor, string name, string breed, bool isItVaccinated, string coatColor, DateTime birthDate) : base(notificationService, height, weight, eyeColor, name, breed, isItVaccinated, coatColor, birthDate)
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
			NotificationService.WriteLine($"\tСобака {(IsItTrained ? "тренированная" : "не тренированная")}");
		}


	}
}
