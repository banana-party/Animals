using Animals.Commands;
using Animals.Console.FileWorkers;
using Animals.Core.Business;
using Animals.Core.Exceptions;
using Animals.Core.Interfaces;
using Animals.Factory;
using System;
using System.Collections.Generic;

namespace Animals.Console.Services
{
	class ConsoleMenuService
	{
		private readonly IReaderService _reader;
		private readonly INotificationService _notification;
		private readonly IMakeASoundable _sound;
		private IFileReader _fileReader;
		private IFileWriter _fileWriter;
		private Dictionary<string, ICommand> _dict;
		private readonly ConsoleAnimalCreatorService _service;
		private Zoo _zoo;
		public ConsoleMenuService(Zoo zoo)
		{
			_reader = new ConsoleReaderService();
			_notification = new ConsoleNotificationService(); //Сервисы ввода/вывода в консоль
			_sound = ConsoleSoundService.CreateSoundService(); 

			_fileReader = new FileReader(_sound);
			_fileWriter = new FileWriter();

			_service = new ConsoleAnimalCreatorService(_reader, _notification);
			AnimalsFactory factory = AnimalsFactory.CreateFactory(_service);
			_zoo = zoo;

			_dict = new Dictionary<string, ICommand>()
			{
				{"1", new AddAnimalCommand(_zoo, factory, _notification, _reader) }, // TODO: Вводить "ваше животное успешно добавлено"
				{"2", new DeleteAnimalCommand(_zoo, _notification, _reader) },	 // TODO: Вводить "ваше животное успешно удалено"
				{"3", new PrintAnimalInfoCommand(_zoo, _notification, _reader)},
				{"4", new AnimalMakeSoundCommand(_zoo, _notification, _reader) },
				{"5", new PrintAllAnimalsInfoCommand(_zoo, _notification) },
				{"6", new AllAnimalMakeSoundCommand(_zoo) },
				{"7", new FileReadCommand(_zoo, _notification, _reader, _fileReader) },
				{"8", new FileWriteCommand(_zoo, _fileWriter) }
			};

		}
		public void PerformAction()
		{
			while (true)
			{
				System.Console.Clear();
				PrintAnimalsList(_zoo);
				PrintMenu(_dict); // TODO: проверить. иногда пропадает
				string i = _reader.ReadLine();
				try
				{
					if (_dict.ContainsKey(i))
					{
						_dict[i].Execute();
						System.Console.ReadKey();
					}
					else if (i == "0") // TODO: Подумать как избавиться от этого условия
						return;
					else
					{
						_notification.Write("Нет такой команды.\n");
						System.Console.ReadKey();
					}
				}
				catch (IndexOutOfRangeException)
				{
					_notification.Write("Индекс вне области\n");
					System.Console.ReadKey();
				}
				catch (IncorrectActionException e)
				{
					_notification.Write(e.Message + "\n");
					System.Console.ReadKey();
				}
			}
		}

		public void PrintMenu(Dictionary<string, ICommand> dict)
		{
			foreach (var item in dict)
				_notification.Write($"{item.Key} - {item.Value}\n");
			_notification.Write("0 - Выход\n");
		}
		public void PrintAnimalsList(Zoo zoo) // TODO: Удалить в релизе
		{
			for (int i = 0; i < zoo.Count; i++)
			{
				_notification.Write($"{i + 1}. {zoo.GetRusTypeOfAnimal(i)}\n");
			}
		}
	}

}
