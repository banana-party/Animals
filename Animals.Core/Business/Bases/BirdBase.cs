using Animals.Core.Interfaces;
//Всё нормально
namespace Animals.Core.Business.Bases
{
	public abstract class BirdBase : AnimalBase
	{
		public int FlyHeight { get; }
		protected BirdBase(float height, float weight, string eyeColor, int flyHeight, IMakeASoundable aSound) : base( height, weight, eyeColor, aSound)
		{
			FlyHeight = flyHeight;
		}
		//Лишний метод? Метод можно было реализовать лучше
		public string Fly()
		{
			return $"Я лечу на высоте {FlyHeight} метров!";
		}
		//Метод можно было реализовать лучше
		public override string ToString()
		{
			return $"{base.ToString()},{FlyHeight}";
		}
	}
}

