using Animals.Core.Business.Instances;
using Animals.Core.Constants;
using Animals.Core.Exceptions;
using Animals.Core.Interfaces;

namespace Animals.WPF.Services.Creators
{
    public class WpfFactory : IFactory
    {
        private static WpfFactory _factory;
        private readonly IDialogService _dialogService;
        private WpfFactory(IDialogService dialogService)
        {
            _dialogService = dialogService;
        }

        public static WpfFactory CreateFactory(IDialogService dialogService) => _factory ??= new WpfFactory(dialogService);
        public IAnimal CreateAnimal(string type)
        {
            return type switch
            {
                Consts.Cat => new Cat(new SoundService(Consts.GetCatSoundPath), _dialogService),
                Consts.Dog => new Dog(new SoundService(Consts.GetDogSoundPath), _dialogService),
                Consts.Chicken => new Chicken(new SoundService(Consts.GetChcikenSoundPath), _dialogService),
                Consts.Stork => new Stork(new SoundService(Consts.GetStorkSoundPath), _dialogService),
                Consts.Wolf => new Wolf(new SoundService(Consts.GetWolfSoundPath), _dialogService),
                Consts.Tiger => new Tiger(new SoundService(Consts.GetTigerSoundPath), _dialogService),
                _ => throw new IncorrectActionException("There is no animal like this")
            };
        }
    }
}
