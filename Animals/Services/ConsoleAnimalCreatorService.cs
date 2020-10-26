using Animals.Buisness.Instances;
using Animals.Core.Interfaces;
using System;

namespace Animals.Menu
{
	internal class ConsoleAnimalCreatorService : IAnimalCreator
	{
		private INotificationService _notificationService;
		private IReaderService _readerService;
		public ConsoleAnimalCreatorService(IReaderService readerService, INotificationService notificationService)
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
			_notificationService.Write("Введите вес:");
			float weight;
			while (!float.TryParse(_readerService.ReadLine(), out weight))
			{
				_notificationService.Write("Не корректрый формат данных.");
				_notificationService.Write("Введите вес:");
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
				if (choose == "Д" || choose == "д" || choose == "Y" || choose == "y")
					return true;

				else if (choose == "Н" || choose == "н" || choose == "N" || choose == "n")
					return false;

				else
					_notificationService.WriteLine("Не верный формат. Повторите ввод.");

			} while (true);
		}
		private DateTime? DateEnter(string text)
		{
			bool isItReady = false;
			DateTime? res = null;
			while (!isItReady)
			{
				_notificationService.Write($"{text} (dd.mm.yyyy): ");
				var lst = _readerService.ReadLine().Split('.');
				try
				{
					res = new DateTime(int.Parse(lst[2]), int.Parse(lst[1]), int.Parse(lst[0]));
				}
				catch (FormatException e)
				{
					_notificationService.WriteLine(e.Message);
					continue;
				}
				catch (ArgumentNullException e)
				{
					_notificationService.WriteLine(e.Message);
					continue;
				}
				catch (ArgumentOutOfRangeException)
				{
					_notificationService.WriteLine("Не корректный формат даты.");
					continue;
				}
				catch (IndexOutOfRangeException)
				{
					_notificationService.WriteLine("Не корректный формат даты.");
					continue;
				}
				isItReady = true;
			}
			return res;
		}
		public IAnimal CreateCat()
		{
			var tuple = AnimalParams();
			float height = tuple.Item1; float weight = tuple.Item2; string eyeColor = tuple.Item3;


			_notificationService.Write("Введите имя: ");
			string name = _readerService.ReadLine();
			_notificationService.Write("Введите породу: ");
			string breed = _readerService.ReadLine();

			bool isItWooled = BoolEnter("У нее есть шерсть?");

			string coatColor;
			if (isItWooled)
			{
				_notificationService.Write("Введите цвет шерсти: ");
				coatColor = _readerService.ReadLine();
			}
			else
				coatColor = "Шерсти нет";

			bool isItVaccinated = BoolEnter("У нее есть прививки?");
			DateTime birthDate = (DateTime)DateEnter("Введите дату рождения"); // Приведение к DateTime, т.к. компилятор ругается что возможен null, но по-моему, не возможен.
			return new Cat(isItWooled, height, weight, eyeColor, name, breed, isItVaccinated, coatColor, birthDate);
		}
		public IAnimal CreateDog()
		{
			var tuple = AnimalParams();
			float height = tuple.Item1;
			float weight = tuple.Item2;
			string eyeColor = tuple.Item3;


			_notificationService.Write("Введите имя: ");
			string name = _readerService.ReadLine();
			_notificationService.Write("Введите породу:");
			string breed = _readerService.ReadLine();

			_notificationService.Write("Введите цвет шерсти: ");
			string coatColor = _readerService.ReadLine();

			bool isItVaccinated = BoolEnter("У нее есть прививки?");
			DateTime birthDate = (DateTime)DateEnter("Введите дату рождения"); // Приведение к DateTime, т.к. компилятор ругается что возможен нулл, но по-моему, не возможен.

			bool isItTrained = BoolEnter("Собака тренированная?");
			return new Dog(isItTrained, height, weight, eyeColor, name, breed, isItVaccinated, coatColor, birthDate);
		}
		public IAnimal CreateChicken()
		{
			var tuple = AnimalParams();
			float height = tuple.Item1;
			float weight = tuple.Item2;
			string eyeColor = tuple.Item3;

			return new Chicken(height, weight, eyeColor, 0);
		}
		public IAnimal CreateStork()
		{
			var tuple = AnimalParams();
			float height = tuple.Item1;
			float weight = tuple.Item2;
			string eyeColor = tuple.Item3;

			return new Stork(height, weight, eyeColor, 200);
		}
		public IAnimal CreateTiger()
		{
			var tuple = AnimalParams();
			float height = tuple.Item1;
			float weight = tuple.Item2;
			string eyeColor = tuple.Item3;

			_notificationService.Write("Введите среду обитания: ");
			string habitat = _readerService.ReadLine();

			DateTime dateOfFind = (DateTime)DateEnter("Введите дату нахождения");

			return new Tiger(height, weight, eyeColor, habitat, dateOfFind);
		}
		public IAnimal CreateWolf()
		{
			var tuple = AnimalParams();
			float height = tuple.Item1;
			float weight = tuple.Item2;
			string eyeColor = tuple.Item3;

			_notificationService.Write("Введите среду обитания: ");
			string habitat = _readerService.ReadLine();

			DateTime dateOfFind = (DateTime)DateEnter("Введите дату нахождения");
			bool isItAlpha = BoolEnter("Он вожак стаи?");


			return new Wolf(isItAlpha, height, weight, eyeColor, habitat, dateOfFind);
		}


	}

}

