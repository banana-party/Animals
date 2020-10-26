using Animals.Core.Interfaces;

namespace Animals.Bases
{
	public abstract class BirdBase : AnimalBase
	{
		protected int FlyHeight;
		private IFlyable _flyable;
		protected BirdBase(float height, float weight, string eyeColor, int flyHeight, IFlyable flyable) : base(height, weight, eyeColor)
		{
			FlyHeight = flyHeight;
			_flyable = flyable;
		}
		public void Fly()
		{
			_flyable.Fly();
		}

		public override void PrintInfo()
		{
			//TODO Реализовать метод
		}
	}
}
