using Animals.Core.Business.Bases;
using Animals.Core.Interfaces;
// Хорошо всё
namespace Animals.Core.Business.Instances
{
	public class Stork : BirdBase
	{
		public Stork(float height, float weight, string eyeColor, int flyHeight, IMakeASoundable aSound) : base(height, weight, eyeColor, flyHeight, aSound)
		{
		}
		public override void MakeASound()
		{
			ASound.MakeASound("ААААИАИАИАИАААА");
		}
	}
}
