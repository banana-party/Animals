using Animals.Bases;

namespace Animals.Buisness.Instances
{
	public class Chicken : BirdBase
	{
		public Chicken(float height, float weight, string eyeColor, int flyheight) : base(height, weight, eyeColor, flyheight)
		{
		}

		public override void MakeASound()
		{
			//TODO реализовать метод
		}
	}
}
