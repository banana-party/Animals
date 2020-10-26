using Animals.Core.Interfaces;

namespace Animals.Bases
{
	public abstract class BirdBase : AnimalBase
	{
		protected int FlyHeight;
		protected BirdBase(float height, float weight, string eyeColor, int flyHeight) : base(height, weight, eyeColor)
		{
			FlyHeight = flyHeight;
		}
		public void Fly()
		{
			//TODO Реализовать метод
		}

		public override void PrintInfo()
		{
			//TODO Реализовать метод
		}
	}
}
