using Animals.Core.Interfaces;

namespace Animals.Bases
{
	public abstract class BaseAnimal : IAnimal
	{
		protected BaseAnimal(float height, float weight, string eyeColor)
		{
			Height = height;
			Weight = weight;
			EyeColor = eyeColor;
		}
		protected float Height;
		protected float Weight;
		protected string EyeColor;
		public abstract void MakeASound();
		public abstract void PrintInfo();
	
	}
}
