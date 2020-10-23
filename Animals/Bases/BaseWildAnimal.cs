using Animals.Core.Interfaces;
using System;

namespace Animals.Bases
{
	public abstract class BaseWildAnimal : BaseAnimal
	{
		protected BaseWildAnimal(float height, float weight, string eyeColor, string habitat, DateTime dateOfFind) : base(height, weight, eyeColor)
		{
			Habitat = habitat;
			DateOfFind = dateOfFind;
		}
		public string Habitat { get; set; }
		public DateTime DateOfFind { get; set; }
		public override void PrintInfo()
		{
			//TODO Реализовать метод
		}
	}
}
