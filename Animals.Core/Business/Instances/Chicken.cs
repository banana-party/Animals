using Animals.Core.Business.Bases;
using Animals.Core.Interfaces;
//Хорошо всё
namespace Animals.Core.Business.Instances
{
	public class Chicken : BirdBase
	{
		public Chicken(float height, float weight, string eyeColor, int flyheight, IMakeASoundable aSound) : base(height, weight, eyeColor, flyheight, aSound)
		{
		}
		//метод можно было реализовать лучше
		public override void MakeASound()
		{
			ASound.MakeASound();
		}
	}
}
