using System.Collections.Generic;
using Animals.Console.Commands.Bases;
using Animals.Console.Services.Creators;
using Animals.Core.Business;
using Animals.Core.Constants;
using Animals.Core.Exceptions;
using Animals.Core.Interfaces;

namespace Animals.Console.Commands
{
	public class AddAnimalCommand : DialogAndReaderCommandBase
	{
        private readonly Dictionary<string, string> _dict;
		private readonly ConsoleFactory _factory;
		public AddAnimalCommand(Zoo zoo, ConsoleFactory factory, IDialogService dialog, IReaderService readerService) : base(zoo, dialog, readerService)
		{
			_dict = new Dictionary<string, string>()
			{
				{ "1", Consts.Cat },
				{ "2", Consts.Dog },
				{ "3", Consts.Chicken },
				{ "4", Consts.Stork },
				{ "5", Consts.Tiger },
				{ "6", Consts.Wolf }
			};
			_factory = factory;
		}

		public override void Execute()
		{
            DialogService.ShowMessage("Выберете животное, которое хотите добавить:\n1 - Кошка\n2 - Собака\n3 - Курица\n4 - Аист\n5 - Тигр\n6 - Волк\n");
			string choose = ReaderService.ReadLine();
			//Необходима проверка на наличие команды в выборе
			if (_dict.ContainsKey(choose))
				Zoo.Add(_factory.CreateAnimal(_dict[choose]));
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
