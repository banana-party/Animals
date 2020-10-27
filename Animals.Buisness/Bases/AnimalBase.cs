﻿using Animals.Core.Interfaces;
using System.Text;

namespace Animals.Bases
{
	public abstract class AnimalBase : IAnimal
	{
		protected INotificationService NotificationService;
		protected AnimalBase(INotificationService notificationService, float height, float weight, string eyeColor)
		{
			Height = height;
			Weight = weight;
			EyeColor = eyeColor;
			NotificationService = notificationService;
		}
		protected float Height;
		protected float Weight;
		protected string EyeColor;
		public abstract void MakeASound();
		public virtual void PrintInfo()
		{
			NotificationService.WriteLine($"{Type()}:\n\tРост: {Height}\n\tВес: {Weight}\n\tЦвет глаз: {EyeColor}");
		}
		public string Type()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(this.GetType());
			stringBuilder.Remove(0, 27);
			return TypeFromEngToRus(stringBuilder.ToString());
		}
		private string TypeFromEngToRus(string type)
		{
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
