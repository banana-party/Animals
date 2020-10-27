using Animals.Core.Interfaces;
using System;

namespace Animals.Core.Business.Bases
{
	public abstract class HomeAnimalBase : AnimalBase
	{
		protected HomeAnimalBase(INotificationService notificationService, float height, float weight, string eyeColor, string name, string breed, bool isItVaccinated, string coatColor, DateTime birthDate) : base(notificationService, height, weight, eyeColor)
		{
			Name = name;
			Breed = breed;
			IsItVaccinated = isItVaccinated;
			CoatColor = coatColor;
			BirthDate = birthDate;
		}
		public string Name { get; set; }
		public string Breed { get; set; }
		public bool IsItVaccinated { get; set; }
		public string CoatColor { get; set; }
		public DateTime BirthDate { get; set; }
		public abstract void Care();
		public override void PrintInfo()
		{
			base.PrintInfo();
			NotificationService.WriteLine($"\tИмя: {Name}\n\tПорода: {Breed}\n\tПрививки {(IsItVaccinated ? "есть" : "отсутствуют")}\n\tЦвет шерсти: {CoatColor}\n\tДата рождения: {BirthDate.Date}");
		}
	}
}
