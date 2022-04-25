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
                try
                { 
                    ValueEnter(weight, f => f > 0);
                }
                catch (Exception e)
                {
                    NotificationService.Write(e.Message);
                    continue;
                }
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
                if (choose == "Н" || choose == "н" || choose == "N" || choose == "n")
                    return false;

                NotificationService.Write("Не верный формат. Повторите ввод.\n");
            } while (true);
        }
        protected DateTime? DateEnter(string text)
        {
            NotificationService.Write($"{text} (dd.mm.yyyy): ");
            try
            {
                return DateTime.Parse(ReaderService.ReadLine());
            }
            catch (Exception e)
            {
                NotificationService.Write(e.Message);
                throw;
            }
        }

        protected T ValueEnter<T>(T value, Predicate<T> predicate)
        {
            //TODO: Подобрать подходящий эксепшн
            return predicate(value) ? value : throw new Exception("Incorrect value.");
        }
    }
}
