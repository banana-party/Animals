using Animals.Core.Interfaces;
using System;

namespace Animals.Core.Business.Bases
{
	public abstract class WildAnimalBase : AnimalBase
	{
		protected WildAnimalBase(INotificationService notificationService, float height, float weight, string eyeColor, string habitat, DateTime dateOfFind) : base(notificationService, height, weight, eyeColor)
		{
			Habitat = habitat;
			DateOfFind = dateOfFind;
		}
		public string Habitat { get; set; }
		public DateTime DateOfFind { get; set; }
		public override void PrintInfo()
		{
			base.PrintInfo();
			NotificationService.WriteLine($"\tСреда обитания: {Habitat}\n\tДата нахождения: {DateOfFind}");
		}
	}
}
