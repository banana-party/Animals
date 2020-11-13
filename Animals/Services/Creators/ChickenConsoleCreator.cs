using Animals.Core.Business.Instances;
using Animals.Core.Interfaces;

namespace Animals.Console.Services.Creators
{
	public class ChickenConsoleCreator : BaseAnimalConsoleCreator
	{
		public ChickenConsoleCreator(IReaderService readerService, INotificationService notificationService) : base(readerService, notificationService)
		{
			SoundService = ConsoleSoundService.CreateSoundService("Пок-пок-пок");
		}

		public override IAnimal Create()
		{
			var tuple = AnimalParams();
			float height = tuple.Item1;
			float weight = tuple.Item2;
			string eyeColor = tuple.Item3;

			return new Chicken( height, weight, eyeColor, 0, SoundService);
		}
	}
}
