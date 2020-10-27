using Animals.Buisness;
using Animals.Commands;
using Animals.Core.Interfaces;
using Animals.Exceptions;
using Animals.Factory;
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
		//static StreamReader fileReader;
		//static IFileWriter fileWriter;
		static void Main(string[] args)
		{
			Zoo zoo = new Zoo();
			reader = new ConsoleReaderService();
			notification = new ConsoleNotificationService();
			ConsoleAnimalCreatorService service = new ConsoleAnimalCreatorService(reader , notification);
			SimpleFactory factory = SimpleFactory.CreateFactory(service);
			Dictionary<string, ICommand> dict = new Dictionary<string, ICommand>()
			{
				{"1", new AddAnimalCommand(zoo, factory, reader, notification) },
				{"2", new DeleteAnimalCommand(zoo, reader, notification) },
				{"3", new PrintAnimalInfoCommand(zoo, reader, notification)},
				{"4", new AnimalMakeSoundCommand(zoo, reader, notification) },
				{"5", new PrintAllAnimalsInfoCommand(zoo) },
				{"6", new AllAnimalMakeSoundCommand(zoo) }
			};
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

		//static void OpenFile(string path)
		//{
		//	fileReader = new StreamReader(path);
		//	while(!fileReader.EndOfStream)
		//	{
		//		var str = fileReader.ReadLine();
				
		//	}
		//}
	}
}
