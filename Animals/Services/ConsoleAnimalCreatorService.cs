using Animals.Console.Services.Creators;
using Animals.Core.Exceptions;
using Animals.Core.Interfaces;

namespace Animals.Console.Services
{
	internal class ConsoleAnimalCreatorService : IAnimalCreator
	{
		private BaseAnimalConsoleCreator _animalCreator;
		private readonly IReaderService _readerService;
		private readonly INotificationService _notificationService;
		public ConsoleAnimalCreatorService(IReaderService readerService, INotificationService notificationService)
		{
			_readerService = readerService;
			_notificationService = notificationService;
		}
		public IAnimal Create(string type)
        {
            //Этод код можно было вынести в отдельный фабричный метод или сделать его шаблонным методом
            _animalCreator = type switch
            {
                "Cat" => (BaseAnimalConsoleCreator) new CatConsoleCreator(_readerService, _notificationService),
                "Dog" => new DogConsoleCreator(_readerService, _notificationService),
                "Chicken" => new ChickenConsoleCreator(_readerService, _notificationService),
                "Stork" => new StorkConsoleCreator(_readerService, _notificationService),
                "Wolf" => new WolfConsoleCreator(_readerService, _notificationService),
                "Tiger" => new TigerConsoleCreator(_readerService, _notificationService),
                _ => throw new IncorrectActionException("There is no animal like this")
            };
            return _animalCreator.Create();
        }
	}

}

