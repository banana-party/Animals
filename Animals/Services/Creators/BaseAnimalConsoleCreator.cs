using Animals.Core.Interfaces;
using System;
//Лучше убрать лишние методы считывания булей интов, даты и прочего из базового класса, а лучше сделать отдельные
//сервисы или Extensionы
namespace Animals.Console.Services.Creators
{
	public abstract class BaseAnimalConsoleCreator
	{
		protected readonly INotificationService NotificationService;
		protected readonly IReaderService ReaderService;
		protected IMakeASoundable SoundService;
		protected BaseAnimalConsoleCreator(IReaderService readerService, INotificationService notificationService)
		{
			NotificationService = notificationService;
			ReaderService = readerService;
		}
		public abstract IAnimal Create();
		protected Tuple<float, float, string> AnimalParams()
		{
			//Повторяющиеся действия с проверкой корректности и считывания можно было вынести с отдельный
			//сервис или Extension
			NotificationService.Write("Введите рост:");
			float height;
			while (!float.TryParse(ReaderService.ReadLine(), out height))
			{
				NotificationService.Write("Не корректрый формат данных.");
				NotificationService.Write("Введите рост:");
			}
			NotificationService.Write("Введите вес:");
			float weight;
			while (!float.TryParse(ReaderService.ReadLine(), out weight))
			{
				NotificationService.Write("Не корректрый формат данных.");
				NotificationService.Write("Введите вес:");
			}
			NotificationService.Write("Введите цвет глаз:");
			string eyeColor = ReaderService.ReadLine();
			//Tuple - удобно, но не очень объектно-ориентировано, надо об этом подумать
			return new Tuple<float, float, string>(height, weight, eyeColor);
		}
		protected bool BoolEnter(string text)
		{
			do
			{
				//Использование else лишнее, а так же у Вас есть IDialogService где у вас есть метод ShowYesNoDialog
				//лучше это всё вынести в этот сервис консольной реализации
				NotificationService.Write($"{text} (Д/Н)");
				string choose = ReaderService.ReadLine();
				if (choose == "Д" || choose == "д" || choose == "Y" || choose == "y")
					return true;
				else if (choose == "Н" || choose == "н" || choose == "N" || choose == "n")
					return false;
				else
					NotificationService.Write("Не верный формат. Повторите ввод.\n");
			} while (true);
		}
		protected DateTime? DateEnter(string text)
		{
			bool isItReady = false;
			DateTime? res = null;
			while (!isItReady)
			{
				NotificationService.Write($"{text} (dd.mm.yyyy): "); //TODO: DateTime.Parse или TryParse
				var lst = ReaderService.ReadLine().Split('.');
				try
				{
					res = new DateTime(int.Parse(lst[2]), int.Parse(lst[1]), int.Parse(lst[0]));
				}
				catch (FormatException e)
				{
					NotificationService.Write(e.Message);
					continue;
				}
				catch (ArgumentNullException e)
				{
					NotificationService.Write(e.Message);
					continue;
				}
				catch (ArgumentOutOfRangeException)
				{
					NotificationService.Write("Не корректный формат даты.\n");
					continue;
				}
				catch (IndexOutOfRangeException)
				{
					NotificationService.Write("Не корректный формат даты.\n");
					continue;
				}
				isItReady = true;
			}
			return res;
		}
	}
}
