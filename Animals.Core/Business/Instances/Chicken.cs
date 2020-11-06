using Animals.Core.Business.Bases;
using Animals.Core.Interfaces;
//Хорошо всё
namespace Animals.Core.Business.Instances
{
	public class Chicken : BirdBase
	{
		public Chicken(IMakeASoundable aSound, INotificationService notificationService, float height, float weight, string eyeColor, int flyheight) : base(aSound, notificationService, height, weight, eyeColor, flyheight)
		{
		}
		public override void MakeASound()
		{
			ASound.MakeASound("Пок-пок-пок");
		}
	}
}
