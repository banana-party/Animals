using Animals.Core.Exceptions;
using Animals.Core.Interfaces;
namespace Animals.Factory
{
	public class AnimalsFactory
	{
        //поле, изменяемое только конструкторе лучше делать readonly
		private IAnimalCreator _animalCreator;
		private AnimalsFactory(IAnimalCreator animalCreator)
		{
			_animalCreator = animalCreator;
		}
		private static AnimalsFactory _factory;
		public static AnimalsFactory CreateFactory(IAnimalCreator animalCreator)
		{
			//Лучше использовать оператор ??
			if (_factory == null)
				_factory = new AnimalsFactory(animalCreator);
			return _factory;
		}
        /*Очень костыльная нерасширяемая реализация этого
         метода вот совсем мне не нравится эта реализация, можно было тут тоже сделать
		какую-нибудь команду и фабрику команд, но то, что Вы по сути сделали не совсем
		даже фабрика объектов или фабричный метод да ещё и в Вашем IAnimalCreatorе нарушили
		SOLID принципы*/ 
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
