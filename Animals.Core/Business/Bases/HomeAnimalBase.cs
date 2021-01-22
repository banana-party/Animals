using Animals.Core.Exctensions;
using Animals.Core.Interfaces;
using System;
//Отличный базовый класс
namespace Animals.Core.Business.Bases
{
	public abstract class HomeAnimalBase : AnimalBase
	{
		protected HomeAnimalBase(float height, float weight, string eyeColor, string name, string breed, bool isItVaccinated, string coatColor, DateTime birthDate, IMakeASoundable aSound) 
			: base(height, weight, eyeColor, aSound)
		{
			Name = name;
			Breed = breed;
			IsItVaccinated = isItVaccinated;
			CoatColor = coatColor;
			BirthDate = birthDate;
		}
		public string Name { get; set; }
		public string Breed { get; }
		public bool IsItVaccinated { get; }
		public string CoatColor { get; }
		public DateTime BirthDate { get; }
		//Лишний метод? Можно было его лучше написать
		public string Care()
		{
			return $"{this.RusType()} проявляет заботу о вас..";
		}
		//метод можно было неаписать лучше
		public override string ToString()
		{
			return $"{base.ToString()},{Name},{Breed},{IsItVaccinated},{CoatColor},{BirthDate.Day}.{BirthDate.Month}.{BirthDate.Year}";
		}
	}
}
