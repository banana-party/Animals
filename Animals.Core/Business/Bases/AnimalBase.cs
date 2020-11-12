using Animals.Core.Exctensions;
using Animals.Core.Interfaces;
using System.Text;

namespace Animals.Core.Business.Bases
{
	public abstract class AnimalBase : IAnimal
	{
		protected IMakeASoundable ASound;
		protected AnimalBase(float height, float weight, string eyeColor, IMakeASoundable aSound)
		{
			Height = height;
			Weight = weight;
			EyeColor = eyeColor;
			ASound = aSound;
		}
		//у этих свойств private set можно было не писать
		public float Height { get; }
		public float Weight { get; }
		public string EyeColor { get; }
		public abstract void MakeASound();
		public override string ToString()
		{
			return $"{this.Type()},{Height},{Weight},{EyeColor}";
		}

	}

}