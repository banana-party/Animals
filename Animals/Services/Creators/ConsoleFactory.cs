using Animals.Core.Constants;
using Animals.Core.Exceptions;
using Animals.Core.Interfaces;

namespace Animals.Console.Services.Creators
{
    public class ConsoleFactory : IFactory
    {
        private BaseAnimalConsoleCreator _animalConsoleCreator;
        private readonly IReaderService _readerService;
        private readonly IDialogService _dialogService;
        private ConsoleFactory(IReaderService reader, IDialogService dialog)
        {
            _readerService = reader;
            _dialogService = dialog;
        }
        private static ConsoleFactory _factory;

        public static ConsoleFactory CreateFactory(IReaderService reader, IDialogService dialog)
        {
            return _factory ??= new ConsoleFactory(reader, dialog);
        }

        public IAnimal CreateAnimal(string type)
        { 
            _animalConsoleCreator = type switch
            {
                Consts.Cat => new CatConsoleCreator(_readerService, _dialogService),
                Consts.Dog => new DogConsoleCreator(_readerService, _dialogService),
                Consts.Chicken => new ChickenConsoleCreator(_readerService, _dialogService),
                Consts.Stork => new StorkConsoleCreator(_readerService, _dialogService),
                Consts.Wolf => new WolfConsoleCreator(_readerService, _dialogService),
                Consts.Tiger => new TigerConsoleCreator(_readerService, _dialogService),
                _ => throw new IncorrectActionException("There is no animal like this")
            };
            return _animalConsoleCreator.Create();
        }

    }
}
