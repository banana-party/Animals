using Animals.Core.Interfaces;

namespace Animals.Bases
{
	public abstract class AnimalBase : IAnimal
	{
		protected AnimalBase(float height, float weight, string eyeColor)
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
