using Animals.Interfaces;

namespace Animals.Bases
{
	//1.Рост животного
	//2.Вес животного
	//3.Цвет глаз животного
	public abstract class BaseAnimal : IAnimal
	{
		public float Height { get; private set; }
		public float Weight { get; private set; }
		public string EyeColor { get; private set; }
		public abstract void MakeASound();
		public abstract void PrintInfo();
	}
}
