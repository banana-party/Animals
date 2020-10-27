using Animals.Bases;
using Animals.Core.Interfaces;
using System;

namespace Animals.Buisness.Instances
{
	public class Tiger : WildAnimalBase
	{
		public Tiger(INotificationService notificationService, float height, float weight, string eyeColor, string habitat, DateTime dateOfFind) : base(notificationService, height, weight, eyeColor, habitat, dateOfFind)
		{
		}
		public override void MakeASound()
		{
			//TODO реализовать метод
		}
	}
}
