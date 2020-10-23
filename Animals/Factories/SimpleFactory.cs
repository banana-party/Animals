using Animals.Core.Interfaces;
using Animals.Exceptions;
using Animals.Instances;

namespace Animals.Factories
{
	public class SimpleFactory
	{

		private SimpleFactory()
		{
		}
		private static SimpleFactory _factory;
		public static SimpleFactory CreateFactory()
		{
			if (_factory == null)
				return new SimpleFactory();
			return _factory;
		}
		public IAnimal GetAnimal(string type)
		{
			IAnimal animal;
			switch (type)
			{
				case "Cat":
					animal = new Cat();
					break;
				case "Dog":
					animal = new Dog();
					break;
				case "Chicken":
					animal = new Chicken();
					break;
				case "Stork":
					animal = new Stork();
					break;
				case "Tiger":
					animal = new Tiger();
					break;
				case "Wolf":
					animal = new Wolf();
					break;
				default:
					throw new IncorrectActionException("There is no animal like this.");
			}
			return animal;
		}
	}

	
}
