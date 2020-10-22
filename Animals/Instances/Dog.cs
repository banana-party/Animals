using Animals.Bases;
using Animals.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Animals.Instances
{
	class Dog : BaseHomeTraineableAnimal
	{

		public Dog(ICareable careable, ISoundable soundable, ITraineble traineble) : base(careable, soundable, traineble)
		{
		}
	}
}
