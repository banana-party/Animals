using Animals.Core.Interfaces;
using Animals.Factories;

namespace Animals.Menu
{
	class AnimalsFacility
	{
		private SimpleFactory _factory;
		private IAnimalCreator _animalCreator;
		public AnimalsFacility(SimpleFactory factory)
		{
			_factory = factory;
		}
		public IAnimal GetAnimal(string type)
		{
			IAnimal animal = _factory.GetAnimal(type);

			return animal;
		}
	}
}
