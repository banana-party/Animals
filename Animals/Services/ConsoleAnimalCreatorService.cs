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
			switch (type)
			{
				case "Cat":
					_animalCreator = new CatConsoleCreator(_readerService, _notificationService);
					break;
				case "Dog":
					_animalCreator = new DogConsoleCreator(_readerService, _notificationService);
					break;
				case "Chicken":
					_animalCreator = new ChickenConsoleCreator(_readerService, _notificationService);
					break;
				case "Stork":
					_animalCreator = new StorkConsoleCreator(_readerService, _notificationService);
					break;
				case "Wolf":
					_animalCreator = new WolfConsoleCreator(_readerService, _notificationService);
					break;
				case "Tiger":
					_animalCreator = new TigerConsoleCreator(_readerService, _notificationService);
					break;
				default:
					throw new IncorrectActionException("There is no animal like this");
			}
			return _animalCreator.Create();
		}
	}

}

