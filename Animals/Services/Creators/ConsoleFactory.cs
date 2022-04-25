using Animals.Core.Constants;
using Animals.Core.Exceptions;
using Animals.Core.Interfaces;

namespace Animals.Console.Services.Creators
{
    public class ConsoleFactory : IFactory
    {
        private BaseAnimalConsoleCreator _animalConsoleCreator;
        private readonly IReaderService _readerService;
        private readonly INotificationService _notificationService;
        private ConsoleFactory(IReaderService reader, INotificationService notification)
        {
            _readerService = reader;
            _notificationService = notification;
        }
        private static ConsoleFactory _factory;

        public static ConsoleFactory CreateFactory(IReaderService reader, INotificationService notification)
        {
            return _factory ??= new ConsoleFactory(reader, notification);
        }

        public IAnimal CreateAnimal(string type)
        { 
            _animalConsoleCreator = type switch
            {
                Consts.Cat => new CatConsoleCreator(_readerService, _notificationService),
                Consts.Dog => new DogConsoleCreator(_readerService, _notificationService),
                Consts.Chicken => new ChickenConsoleCreator(_readerService, _notificationService),
                Consts.Stork => new StorkConsoleCreator(_readerService, _notificationService),
                Consts.Wolf => new WolfConsoleCreator(_readerService, _notificationService),
                Consts.Tiger => new TigerConsoleCreator(_readerService, _notificationService),
                _ => throw new IncorrectActionException("There is no animal like this")
            };
            return _animalConsoleCreator.Create();
        }

    }
}
