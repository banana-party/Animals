using Animals.Interfaces;
using System;

namespace Animals.Bases
{
	public abstract class BaseHomeAnimal : BaseAnimal
	{

		private ICareable _careable;
		protected BaseHomeAnimal(ICareable careable, ISoundable soundable) : base(soundable)
		{
			_careable = careable;
		}
		public string Name { get; set; }
		public string Breed { get; set; }
		public bool IsITVaccinated { get; set; }
		public string CoatColor { get; set; }
		public DateTime BirthDate { get; set; }
		public void Care()
		{
			_careable.Care();
		}
		public override void PrintInfo()
		{
			//TODO Реализовать метод
		}
	}
}
