using Animals.Core.Business.Bases;
using Animals.Core.Interfaces;
// Хорошо всё
namespace Animals.Core.Business.Instances
{
	public class Stork : BirdBase
	{
		public Stork(IMakeASoundable aSound, INotificationService notificationService, float height, float weight, string eyeColor, int flyHeight) : base(aSound, notificationService, height, weight, eyeColor, flyHeight)
		{
		}
		public override void MakeASound()
		{
			ASound.MakeASound("ААААИАИАИАИАААА");
		}
	}
}
