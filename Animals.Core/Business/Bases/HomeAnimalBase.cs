﻿using Animals.Core.Exctensions;
using Animals.Core.Interfaces;
using System;

namespace Animals.Core.Business.Bases
{
	public abstract class HomeAnimalBase : AnimalBase
	{
		protected HomeAnimalBase(float height, float weight, string eyeColor, string name, string breed, bool isItVaccinated, string coatColor, DateTime birthDate, IMakeASoundable aSound) : base(height, weight, eyeColor, aSound)
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
		public string Care()
		{
			return $"{this.Type()} проявляет заботу о вас..";
		}
		//public override void PrintInfo()
		//{
		//	base.PrintInfo();
		//	NotificationService.Write($"\tИмя: {Name}\n\tПорода: {Breed}\n\tПрививки {(IsItVaccinated ? "есть" : "отсутствуют")}\n\t" +
		//		$"Цвет шерсти: {CoatColor}\n\tДата рождения: {BirthDate.Day}.{BirthDate.Month}.{BirthDate.Year}\n");
		//}
		public override string ToString()
		{
			return $"{base.ToString()},{Name},{Breed},{IsItVaccinated},{CoatColor},{BirthDate.Day}.{BirthDate.Month}.{BirthDate.Year}";
		}
	}
}
