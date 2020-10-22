using Animals.Interfaces;
using System;

namespace Animals.Bases
{
	public abstract class BaseWildAnimal : BaseAnimal
	{
		protected BaseWildAnimal(ISoundable soundable) : base(soundable)
		{
		}
		public string Habitat { get; set; }
		public DateTime DateOfFind { get; set; }
		public override void PrintInfo()
		{
			//TODO Реализовать метод
		}
	}
}
