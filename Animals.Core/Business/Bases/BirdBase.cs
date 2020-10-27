using Animals.Core.Interfaces;

namespace Animals.Core.Business.Bases
{
	public abstract class BirdBase : AnimalBase
	{
		protected int FlyHeight;
		protected BirdBase(INotificationService notificationService, float height, float weight, string eyeColor, int flyHeight) : base(notificationService, height, weight, eyeColor)
		{
			FlyHeight = flyHeight;
		}
		public void Fly()
		{
			NotificationService.WriteLine($"Я лечу на высоте {FlyHeight} метров!");
		}

		public override void PrintInfo()
		{
			base.PrintInfo();
			NotificationService.WriteLine($"\tВысота полета: {FlyHeight}");
		}
	}
}

