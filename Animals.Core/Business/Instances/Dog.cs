using Animals.Core.Business.Bases;
using Animals.Core.Interfaces;
using System;
//Хорошо всё
namespace Animals.Core.Business.Instances
{
	public class Dog : HomeAnimalBase
	{
		public bool IsItTrained { get; private set; }
		public Dog(IMakeASoundable aSound, INotificationService notificationService, bool isItTrained, float height, float weight, string eyeColor, string name, string breed, bool isItVaccinated, string coatColor, DateTime birthDate) : base(aSound, notificationService, height, weight, eyeColor, name, breed, isItVaccinated, coatColor, birthDate)
		{
			IsItTrained = isItTrained;
		}
		public void Train()
		{
			if (IsItTrained)
				return;
			else
				IsItTrained = true;
		}
		public override void MakeASound()
		{
			ASound.MakeASound("ГААААВ");
		}

		public override void PrintInfo()
		{
			base.PrintInfo();
			NotificationService.WriteLine($"\tСобака {(IsItTrained ? "тренированная" : "не тренированная")}");
		}


	}
}
