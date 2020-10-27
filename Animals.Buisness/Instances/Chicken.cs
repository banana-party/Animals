using Animals.Bases;
using Animals.Core.Interfaces;

namespace Animals.Buisness.Instances
{
	public class Chicken : BirdBase
	{
		public Chicken(INotificationService notificationService, float height, float weight, string eyeColor, int flyheight) : base(notificationService, height, weight, eyeColor, flyheight)
		{
		}

		public override void MakeASound()
		{
			//TODO реализовать метод
		}
	}
}
