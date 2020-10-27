using Animals.Core.Business.Bases;
using Animals.Core.Interfaces;
using System;

namespace Animals.Core.Business.Instances
{
	public class Wolf : WildAnimalBase
	{
		public bool IsItAlpha { get; }
		public Wolf(IMakeASoundable aSound, INotificationService notificationService, bool isItAlpha, float height, float weight, string eyeColor, string habitat, DateTime dateOfFind) : base(aSound, notificationService, height, weight, eyeColor, habitat, dateOfFind)
		{
			IsItAlpha = isItAlpha;
		}
		public override void MakeASound()
		{
			ASound.MakeASound("ВУУУУУУУУУУ");
		}
		public override void PrintInfo()
		{
			base.PrintInfo();
			NotificationService.WriteLine($"\t{(IsItAlpha ? "Я" : "Не я")}вляется вожаком стаи");
		}
	}

}
