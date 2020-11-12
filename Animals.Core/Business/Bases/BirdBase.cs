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
		public string Fly()
		{
			return $"Я лечу на высоте {FlyHeight} метров!";
		}

		//public override void PrintInfo()
		//{
		//	base.PrintInfo();
		//	NotificationService.Write($"\tВысота полета: {FlyHeight}]n");
		//}
		public override string ToString()
		{
			return $"{base.ToString()},{FlyHeight}";
		}
	}
}

