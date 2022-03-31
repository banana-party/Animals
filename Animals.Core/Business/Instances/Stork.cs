using Animals.Core.Business.Bases;
using Animals.Core.Interfaces;

namespace Animals.Core.Business.Instances
{
	public class Stork : BirdBase
	{
		public Stork(float height, float weight, string eyeColor, int flyHeight, IMakeASoundable aSound) : base(height, weight, eyeColor, flyHeight, aSound)
		{
		}
    }
}
