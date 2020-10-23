using Animals.Core.Interfaces;
using Animals.Instances;
using System;
using System.Collections.Generic;

namespace Animals.Menu
{
	internal class AnimalsCreator : IAnimalCreator
	{
		private INotificationService _notificationService;
		private IReaderService _readerService;
		public AnimalsCreator(IReaderService readerService, INotificationService notificationService)
		{
			_notificationService = notificationService;
			_readerService = readerService;
		}
		private Tuple<float, float, string> AnimalParams()
		{
			_notificationService.Write("Введите рост:");
			float height;
			while (!float.TryParse(_readerService.ReadLine(), out height))
			{
				_notificationService.Write("Не корректрый формат данных.");
				_notificationService.Write("Введите рост:");
			}
			float weight;
			while (!float.TryParse(_readerService.ReadLine(), out weight))
			{
				_notificationService.Write("Не корректрый формат данных.");
				_notificationService.Write("Введите рост:");
			}
			_notificationService.Write("Введите цвет глаз:");
			string eyeColor = _readerService.ReadLine();

			return new Tuple<float, float, string>(height, weight, eyeColor);
		}
		private bool BoolEnter(string text)
		{
			do
			{
				_notificationService.Write($"{text} (Д/Н)");
				string choose = _readerService.ReadLine();
				if (choose == "Д")
				{
					return true;
				}
				else if (choose == "Н")
				{
					return false;
				}
				else
					_notificationService.WriteLine("Не верный формат. Повторите ввод.");

			} while (true);
		}
		private DateTime? DateEnter(string text)
		{
			_notificationService.Write($"{text} (dd.mm.yyyy):");
			bool isItReady = false;
			DateTime? res = null;
			while (!isItReady)
			{
				var str = _readerService.ReadLine();
				var lst = str.Split('.');
				try
				{
					res = new DateTime(int.Parse(lst[0]), int.Parse(lst[1]), int.Parse(lst[2]));
				}
				catch (FormatException e)
				{
					_notificationService.WriteLine(e.Message);
				}
				catch (ArgumentNullException e)
				{
					_notificationService.WriteLine(e.Message);
				}
				catch (ArgumentOutOfRangeException e)
				{
					_notificationService.WriteLine(e.Message);
				}
				isItReady = true;
			}
			return res;
		}
		public IAnimal CreateCat()
		{
			DateTime birthDate;

			var tuple = AnimalParams();
			float height = tuple.Item1;
			float weight = tuple.Item2;
			string eyeColor = tuple.Item3;


			_notificationService.Write("Введите имя:");
			string name = _readerService.ReadLine();
			_notificationService.Write("Введите породу:");
			string breed = _readerService.ReadLine();

			bool isItWooled = BoolEnter("У нее есть шерсть?");

			string coatColor;
			if (isItWooled)
			{
				_notificationService.Write("Введите цвет шерсти:");
				coatColor = _readerService.ReadLine();
			}
			else
				coatColor = "Шерсти нет";

			bool isItVaccinated = BoolEnter("У нее есть прививки?");
			birthDate = (DateTime)DateEnter("Введите дату рождения (dd.mm.yyyy):"); // Приведение к DateTime, т.к. компилятор ругается что возможен нулл, но по-моему, не возможен.
			return new Cat(isItWooled, height, weight, eyeColor, name, breed, isItVaccinated, coatColor, birthDate);
		}


	}
	public IAnimal CreateChicken()
	{
		throw new NotImplementedException();
	}

	public IAnimal CreateDog()
	{
		throw new NotImplementedException();
	}

	public IAnimal CreateStork()
	{
		throw new NotImplementedException();
	}

	public IAnimal CreateTiger()
	{
		throw new NotImplementedException();
	}

	public IAnimal CreateWolf()
	{
		throw new NotImplementedException();
	}
}
}
