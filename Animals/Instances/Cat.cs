using Animals.Bases;
using Animals.Interfaces;
using System;

namespace Animals.Instances
{
	class Cat : BaseHomeAnimal
	{

		public Cat(ICareable careable, ISoundable soundable) : base(careable, soundable)
		{
		}

		public override void PrintInfo()
		{ 
		}
	}
}
