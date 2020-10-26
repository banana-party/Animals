using Animals.Core.Interfaces;
using Animals.Exceptions;
using Animals.Instances;

namespace Animals.Factories
{
	public class SimpleFactory
	{
		private IAnimalCreator _animalCreator;
		private SimpleFactory(IAnimalCreator animalCreator)
		{
			_animalCreator = animalCreator;
		}
		private static SimpleFactory _factory;
		public static SimpleFactory CreateFactory(IAnimalCreator animalCreator)
		{
			if (_factory == null)
				return new SimpleFactory(animalCreator);
			return _factory;
		}
		public IAnimal GetAnimal(string type)
		{
			IAnimal animal;
			switch (type)
			{
				case "Cat":
					animal = _animalCreator.CreateCat();
					break;
				case "Dog":
					animal = _animalCreator.CreateDog();
					break;
				case "Chicken":
					animal = _animalCreator.CreateChicken();
					break;
				case "Stork":
					animal = _animalCreator.CreateStork();
					break;
				case "Tiger":
					animal = _animalCreator.CreateTiger();
					break;
				case "Wolf":
					animal = _animalCreator.CreateWolf();
					break;
				default:
					throw new IncorrectActionException("There is no animal like this.");
			}
			return animal;
		}
	}

	
}
