﻿using Animals.Core.Business.Bases;
//Всё отлично
namespace Animals.Core.Exctensions
{
    public static class AnimalExtension
	{
		//Метод можно было лучше реализовать
		public static string Type(this AnimalBase animal)
		{
			return animal.GetType().Name;
		}
		public static string RusType(this AnimalBase animal)
		{
			var type = animal.Type();
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
