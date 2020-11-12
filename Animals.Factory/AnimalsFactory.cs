using Animals.Core.Interfaces;
namespace Animals.Factory
{
	public class AnimalsFactory
	{

		private readonly IAnimalCreator _animalCreator;
		private AnimalsFactory(IAnimalCreator animalCreator)
		{
			_animalCreator = animalCreator;
		}
		private static AnimalsFactory _factory;
		public static AnimalsFactory CreateFactory(IAnimalCreator animalCreator)
		{
			if(_factory == null)
				_factory = new AnimalsFactory(animalCreator);
			return _factory;
		}
		//получилось, что фабрика вовсе не фабрика, и вся ее реализация переехала в энимал криэйтор
		public IAnimal GetAnimal(string type)
		{
			return _animalCreator.Create(type);
		}
	}


}
