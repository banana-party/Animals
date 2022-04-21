using Animals.Core.Business.Bases;
using Animals.Core.Interfaces;

namespace Animals.Core.Business.Instances
{
	public class Stork : BirdBase
	{
        public Stork(IMakeASoundable sound)
        {
            ASound = sound;
        }
		public Stork(float height, float weight, string eyeColor, int flyHeight, IMakeASoundable aSound) : base(height, weight, eyeColor, flyHeight, aSound)
		{
		}
    }
}
