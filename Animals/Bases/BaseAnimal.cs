using Animals.Core.Interfaces;

namespace Animals.Bases
{
	public abstract class BaseAnimal : IAnimal
	{
		private ISoundable _soundable;
		protected BaseAnimal(ISoundable soundable)
		{
			_soundable = soundable;
		}
		public float Height { get; private set; }
		public float Weight { get; private set; }
		public string EyeColor { get; private set; }
		public void MakeASound()
		{
			_soundable.MakeASound();
		}
		public abstract void PrintInfo();
	
	}
}
