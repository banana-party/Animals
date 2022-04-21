using Animals.Core.Business.Instances;
using Animals.Core.Constants;
using Animals.Core.Exceptions;
using Animals.Core.Interfaces;

namespace Animals.WPF.Services.Creators
{
    public class WpfFactory : IFactory
    {
        private static WpfFactory _factory;
        private WpfFactory()
        {
        }

        public static WpfFactory CreateFactory() => _factory ??= new WpfFactory();
        public IAnimal CreateAnimal(string type)
        {
            return type switch
            {
                "Cat" => new Cat(new SoundService(Consts.GetCatSoundPath)),
                "Dog" => new Dog(new SoundService(Consts.GetDogSoundPath)),
                "Chicken" => new Chicken(new SoundService(Consts.GetChcikenSoundPath)),
                "Stork" => new Stork(new SoundService(Consts.GetStorkSoundPath)),
                "Wolf" => new Wolf(new SoundService(Consts.GetWolfSoundPath)),
                "Tiger" => new Tiger(new SoundService(Consts.GetTigerSoundPath)),
                _ => throw new IncorrectActionException("There is no animal like this")
            };
        }
    }
}
