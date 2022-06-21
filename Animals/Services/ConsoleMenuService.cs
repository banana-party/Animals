using Animals.Commands;
using Animals.Console.FileWorkers;
using Animals.Core.Business;
using Animals.Core.Exceptions;
using Animals.Core.Interfaces;
using System;
using System.Collections.Generic;
using Animals.Console.Commands;
using Animals.Console.Services.Creators;

namespace Animals.Console.Services
{
	class ConsoleMenuService
	{
        private readonly IReaderService _reader;
		private readonly IDialogService _dialog;
		private readonly IAnimalParser _animalParser;
		private readonly IFileReader _fileReader;
		private readonly IFileWriter _fileWriter;
		private readonly Dictionary<string, ICommand> _dict;
		private readonly ConsoleFactory _factory;
		private readonly Zoo _zoo;
		public ConsoleMenuService(Zoo zoo)
		{
			_reader = new ConsoleReaderService();
			_dialog = new ConsoleDialogService(); 
			_animalParser = new ConsoleAnimalParserService(_dialog);

			_fileReader = new FileReader(_animalParser);
			_fileWriter = new FileWriter();

            _factory = ConsoleFactory.Factory ?? ConsoleFactory.CreateFactory(_reader, _dialog);
            _zoo = zoo;

			_dict = new Dictionary<string, ICommand>()
			{
				{"1", new AddAnimalCommand(_zoo, _factory, _dialog, _reader) }, // TODO: Вводить "ваше животное успешно добавлено"
				{"2", new DeleteAnimalCommand(_zoo, _dialog, _reader) },	 // TODO: Вводить "ваше животное успешно удалено"
				{"3", new PrintAnimalInfoCommand(_zoo, _dialog, _reader)},  //TODO: Убрать вывод животных над меню
				{"4", new AnimalMakeSoundCommand(_zoo, _dialog, _reader) }, 
				{"5", new PrintAllAnimalsInfoCommand(_zoo, _dialog) },
				{"6", new AllAnimalMakeSoundCommand(_zoo) },
				{"7", new FileReadCommand(_zoo, _dialog, _reader, _fileReader) },
				{"8", new FileWriteCommand(_zoo, _fileWriter) },
				{"0", new ExitCommand() } 

			};

		}
		public void PerformAction()
		{
			string i;
			do
			{
				System.Console.Clear();
				PrintAnimalsList(_zoo); // TODO: Удалить в релизе
				PrintMenu(_dict); 
				i = _reader.ReadLine();
				try
				{
					if (_dict.ContainsKey(i))
					{
						_dict[i].Execute();
						System.Console.ReadKey();
					}
					else
					{
						_dialog.ShowMessage("Нет такой команды.\n");
						System.Console.ReadKey();
					}
				}
				catch (IndexOutOfRangeException)
				{
					_dialog.ShowMessage("Индекс вне области\n");
					System.Console.ReadKey();
				}
				catch (IncorrectActionException e)
				{
					_dialog.ShowMessage(e.Message + "\n");
					System.Console.ReadKey();
				}
			} while (i != "0");
		}

		public void PrintMenu(Dictionary<string, ICommand> dict)
		{
			foreach (var (key, value) in dict)
				_dialog.ShowMessage($"{key} - {value}\n");
		}
		public void PrintAnimalsList(Zoo zoo) // TODO: Удалить в релизе
		{
			for (int i = 0; i < zoo.Count; i++)
			{
				_dialog.ShowMessage($"{i + 1}. {zoo.GetRusTypeOfAnimal(i)}\n");
			}
		}
	}

}
