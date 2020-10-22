using Animals.Interfaces;
using System;

namespace Animals.Bases
{
	public abstract class BaseHomeAnimal : BaseAnimal
	{

		protected ICareable Care;
		protected BaseHomeAnimal(ICareable careable, ISoundable soundable) : base(soundable)
		{
			Care = careable;
		}
		public string Name { get; set; }
		public string Breed { get; set; }
		public bool IsITVaccinated { get; set; }
		public string CoatColor { get; set; }
		public DateTime BirthDate { get; set; }
		public override void PrintInfo()
		{
		}
	}
}
