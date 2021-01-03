﻿using Animals.Core.Interfaces;
using System;
//Всё хорошо тут
namespace Animals.Core.Business.Bases
{
	public abstract class WildAnimalBase : AnimalBase
	{
		protected WildAnimalBase(float height, float weight, string eyeColor, string habitat, DateTime dateOfFind, IMakeASoundable aSound) : base(height, weight, eyeColor, aSound)
		{
			Habitat = habitat;
			DateOfFind = dateOfFind;
		}
		public string Habitat { get; }
		public DateTime DateOfFind { get; }
		public override string ToString()
		{
			return $"{base.ToString()},{Habitat},{DateOfFind.Day}.{DateOfFind.Month}.{DateOfFind.Year}";
		}
	}
}
