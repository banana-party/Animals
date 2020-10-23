using System;
using System.Collections.Generic;
using System.Text;

namespace Animals.Core.Interfaces
{
	public interface IAnimalCreator
	{
		IAnimal CreateCat();
		IAnimal CreateDog();
		IAnimal CreateChicken();
		IAnimal CreateStork();
		IAnimal CreateTiger();
		IAnimal CreateWolf();
	}
}
