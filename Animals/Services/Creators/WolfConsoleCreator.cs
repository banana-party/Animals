using Animals.Core.Business.Instances;
using Animals.Core.Interfaces;
using System;

namespace Animals.Console.Services.Creators
{
	class WolfConsoleCreator : BaseAnimalConsoleCreator
	{
		public WolfConsoleCreator(IReaderService readerService, INotificationService notificationService) : base(readerService, notificationService)
		{
			SoundService = ConsoleSoundService.CreateSoundService("АУУУУ");
		}

		public override IAnimal Create()
		{
			var tuple = AnimalParams();
			float height = tuple.Item1;
			float weight = tuple.Item2;
			string eyeColor = tuple.Item3;

			NotificationService.Write("Введите среду обитания: ");
			string habitat = ReaderService.ReadLine();

			DateTime dateOfFind = (DateTime)DateEnter("Введите дату нахождения");
			bool isItAlpha = BoolEnter("Он вожак стаи?");

			return new Wolf(height, weight, eyeColor, habitat, dateOfFind, isItAlpha, SoundService);
		}
	}
}
