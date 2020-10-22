using Animals.Core.Interfaces;

namespace Animals.Bases
{
	public abstract class BaseBird : BaseAnimal
	{
		protected int FlyHeight;
		private IFlyable _flyable;
		protected BaseBird(ISoundable soundable, IFlyable flyable) : base(soundable)
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
