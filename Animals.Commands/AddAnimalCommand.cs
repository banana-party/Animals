using Animals.Commands.Bases;
using Animals.Core.Interfaces;
using System.Collections.Generic;
using Animals.Factory;
using Animals.Core.Exceptions;
using Animals.Core.Business;

namespace Animals.Commands
{
	public class AddAnimalCommand : NotificationCommandBase
	{
		private Dictionary<string, string> _dict;
		private AnimalsFactory _factory;
		public AddAnimalCommand(Zoo zoo, AnimalsFactory factory, IReaderService readerService, INotificationService notificationService) : base(zoo, readerService, notificationService)
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
			_notificationService.WriteLine("Выберете животное, которое хотите добавить:\n1 - Кошка\n2 - Собака\n3 - Курица\n4 - Аист\n5 - Тигр\n6 - Волк");
			string choose = _readerService.ReadLine();

			if (_dict.ContainsKey(choose))
			{
				_zoo.Add(_factory.GetAnimal(_dict[choose]));
			}
			else
				throw new IncorrectActionException("Неверный ввод.");
		}
		public override string ToString()
		{
			return "Добавить животное в зоопарк";
		}
	}
}
