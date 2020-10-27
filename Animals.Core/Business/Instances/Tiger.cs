using Animals.Core.Business.Bases;
using Animals.Core.Interfaces;
using System;

namespace Animals.Core.Business.Instances
{
	public class Tiger : WildAnimalBase
	{
		public Tiger(IMakeASoundable aSound, INotificationService notificationService, float height, float weight, string eyeColor, string habitat, DateTime dateOfFind) : base(aSound, notificationService, height, weight, eyeColor, habitat, dateOfFind)
		{
		}
		public override void MakeASound()
		{
			ASound.MakeASound("РЯЯЯЯЯЯ");
		}
	}
}
