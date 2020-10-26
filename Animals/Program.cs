using Animals.Buisness;
using Animals.Commands;
using Animals.Core.Interfaces;
using Animals.Factory;
using Animals.Menu;
using Animals.Services;
using System.Collections.Generic;

namespace Animals
{
	class Program
	{
		static IReaderService reader;
		static INotificationService notification;
		static void Main(string[] args)
		{
			Zoo zoo = new Zoo();
			reader = new ConsoleReaderService();
			notification = new ConsoleNotificationService();
			ConsoleAnimalCreatorService service = new ConsoleAnimalCreatorService(reader , notification);
			SimpleFactory factory = SimpleFactory.CreateFactory(service);
			Dictionary<string, ICommand> dict = new Dictionary<string, ICommand>()
			{
				{"1", new AddAnimalCommand(zoo, factory,reader, notification) },
				{"2", new DeleteAnimalCommand(zoo, reader, notification) },
				{"3", new PrintAnimalInfoCommand(zoo, reader, notification)},
				{"4", new AnimalMakeSoundCommand(zoo, reader, notification) },
				{"5", new PrintAllAnimalsInfoCommand(zoo) },
				{"6", new AllAnimalMakeSoundCommand(zoo) }
			};
			while (true)
			{
				PrintMenu(dict);
				string i = reader.ReadLine();

				if (dict.ContainsKey(i))
				{
					dict[i].Execute();
				}
				else
				{
					notification.WriteLine("Нет такой комманды.");
				}

			}

		}
		static void PrintMenu(Dictionary<string, ICommand> dict)
		{
			foreach (var item in dict)
			{
				notification.WriteLine($"{item.Key} - {item.Value}");
			}
		}
	}
}
