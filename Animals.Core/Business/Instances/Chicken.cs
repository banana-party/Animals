using Animals.Core.Business.Bases;
using Animals.Core.Interfaces;

namespace Animals.Core.Business.Instances
{
	public class Chicken : BirdBase
	{
		public Chicken(float height, float weight, string eyeColor, int flyheight, IMakeASoundable aSound) : base(height, weight, eyeColor, flyheight, aSound)
		{
		}
    }
}
