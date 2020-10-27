using Animals.Bases;
using Animals.Core.Interfaces;

namespace Animals.Buisness.Instances
{
	public class Stork : BirdBase
	{
		public Stork(INotificationService notificationService, float height, float weight, string eyeColor, int flyHeight) : base(notificationService, height, weight, eyeColor, flyHeight)
		{
		}

		public override void MakeASound()
		{
			//TODO реализовать метод
		}
	}
}
