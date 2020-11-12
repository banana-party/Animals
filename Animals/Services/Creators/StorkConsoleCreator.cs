using Animals.Core.Business.Instances;
using Animals.Core.Interfaces;

namespace Animals.Console.Services.Creators
{
	class StorkConsoleCreator : BaseAnimalConsoleCreator
	{
		public StorkConsoleCreator(IReaderService readerService, INotificationService notificationService) : base(readerService, notificationService)
		{
		}

		public override IAnimal Create()
		{
			var tuple = AnimalParams();
			float height = tuple.Item1;
			float weight = tuple.Item2;
			string eyeColor = tuple.Item3;

			return new Stork(height, weight, eyeColor, 200, SoundService);
		}
	}
}
