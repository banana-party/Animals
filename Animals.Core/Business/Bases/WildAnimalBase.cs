using Animals.Core.Interfaces;
using System;
//Всё хорошо тут
namespace Animals.Core.Business.Bases
{
	public abstract class WildAnimalBase : AnimalBase
	{
		protected WildAnimalBase(IMakeASoundable aSound, INotificationService notificationService, float height, float weight, string eyeColor, string habitat, DateTime dateOfFind) : base(aSound, notificationService, height, weight, eyeColor)
		{
			Habitat = habitat;
			DateOfFind = dateOfFind;
		}
		public string Habitat { get; set; }
		public DateTime DateOfFind { get; set; }
		public override void PrintInfo()
		{
			base.PrintInfo();
			NotificationService.WriteLine($"\tСреда обитания: {Habitat}\n\tДата нахождения: {DateOfFind.Day}.{DateOfFind.Month}.{DateOfFind.Year}");
		}
	}
}
