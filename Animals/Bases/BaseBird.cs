using Animals.Core.Interfaces;

namespace Animals.Bases
{
	public abstract class BaseBird : BaseAnimal
	{
		protected int FlyHeight;
		private IFlyable _flyable;
		protected BaseBird(float height, float weight, string eyeColor, IFlyable flyable) : base(height, weight, eyeColor)
		{
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
