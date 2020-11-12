using Animals.Commands;
using Animals.Console.FileWorkers;
using Animals.Console.Services;
using Animals.Core.Business;
using Animals.Core.Business.Instances;
using Animals.Core.Exceptions;
using Animals.Core.Interfaces;
using Animals.Factory;
using System;
using System.Collections.Generic;
using System.IO;

namespace Animals
{
	class Program
	{
		static IReaderService _reader;
		static INotificationService _notification;
		static IMakeASoundable _sound;
		static IFileReader _fileReader;
		static IFileWriter _fileWriter;
		static void Main(string[] args)
		{

			_reader = new ConsoleReaderService();
			_notification = new ConsoleNotificationService();
			_sound = new ConsoleAnimalMakeASondService();

			_fileReader = new FileReader(_sound);
			_fileWriter = new FileWriter();

			Zoo zoo = new Zoo(_fileReader, _fileWriter);
			ConsoleAnimalCreatorService service = new ConsoleAnimalCreatorService(_reader, _notification);
			AnimalsFactory factory = AnimalsFactory.CreateFactory(service);

			// TODO: Посмотреть в видео и создать класс меню, который будет хранить команды
			Dictionary<string, ICommand> dict = new Dictionary<string, ICommand>()
			{
				{"1", new AddAnimalCommand(zoo, factory, _notification, _reader) }, // TODO: Вводить "ваше животное успешно добавлено"
				{"2", new DeleteAnimalCommand(zoo, _notification, _reader) },	 // TODO: Вводить "ваше животное успешно удалено"
				{"3", new PrintAnimalInfoCommand(zoo, _notification, _reader)},
				{"4", new AnimalMakeSoundCommand(zoo, _notification, _reader) },
				{"5", new PrintAllAnimalsInfoCommand(zoo, _notification) },
				{"6", new AllAnimalMakeSoundCommand(zoo) },
				{"7", new FileReadCommand(zoo, _notification, _reader, _fileReader) },
				{"8", new FileWriteCommand(zoo, _fileWriter) }
			}; 
			
			bool a = false;
			while (!a)
			{
				System.Console.Clear();
				PrintAnimalsList(zoo);
				PrintMenu(dict); // TODO: проверить. иногда пропадает
				string i = _reader.ReadLine();
				try
				{
					if (dict.ContainsKey(i))
					{
						dict[i].Execute();
						System.Console.ReadKey();
					}
					else if (i == "0") // TODO: Подумать как избавиться от этого условия
						a = true; 
					else
					{
						_notification.Write("Нет такой команды.\n");
						System.Console.ReadKey();
					}
				}
				catch(IndexOutOfRangeException)
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
		
		static void PrintMenu(Dictionary<string, ICommand> dict)
		{
			foreach (var item in dict)
			{
				_notification.Write($"{item.Key} - {item.Value}\n");
			}
			_notification.Write("0 - Выход\n");
		}
		static void PrintAnimalsList(Zoo zoo) // TODO: Удалить в релизе
		{
			for (int i = 0; i < zoo.Count; i++)
			{
				_notification.Write($"{i + 1}. {zoo.GetTypeOfAnimal(i)}\n");
			}
		}
	}
}
