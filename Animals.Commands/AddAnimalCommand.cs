using Animals.Commands.Bases;
using Animals.Core.Interfaces;
using System.Collections.Generic;
using Animals.Factory;
using Animals.Core.Exceptions;
using Animals.Core.Business;

namespace Animals.Commands
{
	public class AddAnimalCommand : NotificationAndReaderCommandBase
	{
        //Поля можно сделать readonly
		private Dictionary<string, string> _dict;
		private AnimalsFactory _factory;
		public AddAnimalCommand(Zoo zoo, AnimalsFactory factory, INotificationService notificationService, IReaderService readerService) : base(zoo, notificationService, readerService)
		{
			_dict = new Dictionary<string, string>()
			{
				{ "1", "Cat" },
				{ "2", "Dog" },
				{ "3", "Chicken" },
				{ "4", "Stork" },
				{ "5", "Tiger" },
				{ "6", "Wolf" }
			};
			_factory = factory;
		}

		public override void Execute()
		{
			NotificationService.Write("Выберете животное, которое хотите добавить:\n1 - Кошка\n2 - Собака\n3 - Курица\n4 - Аист\n5 - Тигр\n6 - Волк\n");
			string choose = ReaderService.ReadLine();
			//Необходима проверка на наличие команды в выборе
			if (_dict.ContainsKey(choose))
				Zoo.Add(_factory.GetAnimal(_dict[choose]));
			else
				throw new IncorrectActionException("Неверный ввод.");
		}
        //Метод можно было написать лучше
		public override string ToString()
		{
			return "Добавить животное в зоопарк";
		}
	}
}
