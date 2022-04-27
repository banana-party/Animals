using Animals.Core.Business.Bases;
using Animals.Core.Constants;

namespace Animals.Core.Exctensions
{
    public static class AnimalExtension
	{
        public static string Type(this AnimalBase animal)
		{
			return animal.GetType().Name;
		}
		public static string RusType(this AnimalBase animal)
		{
			var type = animal.Type();
			switch (type)
			{
				case Consts.Chicken:
					return "Курица";
				case Consts.Cat:
					return "Кошка";
				case Consts.Dog:
					return "Собака";
				case Consts.Stork:
					return "Аист";
				case Consts.Tiger:
					return "Тигр";
				case Consts.Wolf:
					return "Волк";
				default:
					return type;
			}
		}
	}
}
