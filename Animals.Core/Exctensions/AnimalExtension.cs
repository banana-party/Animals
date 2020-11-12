using Animals.Core.Business.Bases;
using System.Text;

namespace Animals.Core.Exctensions
{
	public static class AnimalExtension
	{
		public static string Type(this AnimalBase animal)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(animal.GetType());
			stringBuilder.Remove(0, 32);                        // вычесть "Animals.Core.Business.Instances."
			string type = stringBuilder.ToString();
			switch (type)
			{
				case "Chicken":
					return "Курица";
				case "Cat":
					return "Кошка";
				case "Dog":
					return "Собака";
				case "Stork":
					return "Аист";
				case "Tiger":
					return "Тигр";
				case "Wolf":
					return "Волк";
				default:
					return type;
			}
		}
	}
}
