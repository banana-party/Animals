using Animals.Core.Exceptions;
using Animals.Core.Interfaces;

namespace Animals.Factory
{
	public class AnimalsFactory
	{
		private IAnimalCreator _animalCreator;
		private AnimalsFactory(IAnimalCreator animalCreator)
		{
			_animalCreator = animalCreator;
		}
		private static AnimalsFactory _factory;
		public static AnimalsFactory CreateFactory(IAnimalCreator animalCreator)
		{
			if (_factory == null)
				_factory = new AnimalsFactory(animalCreator);
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
