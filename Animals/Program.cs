using Animals.Commands;
using Animals.Core.Business;
using Animals.Core.Exceptions;
using Animals.Core.FileParsers;
using Animals.Core.Interfaces;
using Animals.Factory;
using Animals.FileReaders;
using Animals.Menu;
using Animals.Services;
using System;
using System.Collections.Generic;
using System.IO;

namespace Animals
{
	class Program
	{
		static IReaderService reader;
		static INotificationService notification;
		static IMakeASoundable sound;
		static IFileReader fileReader;
		static IFileWriter fileWriter;
		static void Main(string[] args)
		{
			
			reader = new ConsoleReaderService();
			notification = new ConsoleNotificationService();
			sound = new ConsoleAnimalMakeASondService();
			
			fileReader = new FileReader(sound, notification);
			fileReader.Open("Input.txt");
			Zoo zoo = new Zoo(fileReader, fileWriter);

			ConsoleAnimalCreatorService service = new ConsoleAnimalCreatorService(reader, notification, sound);
			AnimalsFactory factory = AnimalsFactory.CreateFactory(service);

			Dictionary<string, ICommand> dict = new Dictionary<string, ICommand>()
			{
				{"1", new AddAnimalCommand(zoo, factory, reader, notification) },
				{"2", new DeleteAnimalCommand(zoo, reader, notification) },
				{"3", new PrintAnimalInfoCommand(zoo, reader, notification)},
				{"4", new AnimalMakeSoundCommand(zoo, reader, notification) },
				{"5", new PrintAllAnimalsInfoCommand(zoo) },
				{"6", new AllAnimalMakeSoundCommand(zoo) }
			};

			zoo.ReadFromFile();

			while (true)
			{
				Console.Clear();
				PrintAnimalsList(zoo);
				PrintMenu(dict);
				string i = reader.ReadLine();
				try
				{
					if (dict.ContainsKey(i))
					{
						dict[i].Execute();
						Console.ReadKey();
					}
					else if (i == "0")
						break;
					else
					{
						notification.WriteLine("Нет такой команды.");
						Console.ReadKey();
					}
				}
				catch(IndexOutOfRangeException)
				{
					notification.WriteLine("Индекс вне области");
					Console.ReadKey();
				}
				catch (IncorrectActionException e)
				{
					notification.WriteLine(e.Message);
					Console.ReadKey();
				}

			}

		}
		static void PrintMenu(Dictionary<string, ICommand> dict)
		{
			foreach (var item in dict)
			{
				notification.WriteLine($"{item.Key} - {item.Value}");
			}
			notification.WriteLine("0 - Выход");
		}
		static void PrintAnimalsList(Zoo zoo)
		{
			for (int i = 0; i < zoo.Count; i++)
			{
				notification.WriteLine($"{i + 1}. {zoo.GetTypeOfAnimal(i)}");
			}
		}
	}
}
