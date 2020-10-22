using Animals.Bases;
using Animals.Core.Interfaces;
using System;

namespace Animals.Instances
{
	class Cat : BaseHomeAnimal
	{

		public Cat(ICareable careable, ISoundable soundable) : base(careable, soundable)
		{
		}
		public bool IsItWooled { get; set; }
		public override void PrintInfo()
		{ 
		}

	}
}
