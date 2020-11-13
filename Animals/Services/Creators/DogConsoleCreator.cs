using Animals.Core.Business.Instances;
using Animals.Core.Interfaces;
using System;

namespace Animals.Console.Services.Creators
{
	public class DogConsoleCreator : BaseAnimalConsoleCreator
	{
		public DogConsoleCreator(IReaderService readerService, INotificationService notificationService) : base(readerService, notificationService)
		{
			SoundService = ConsoleSoundService.CreateSoundService("ГАВ");
		}

		public override IAnimal Create()
		{
			var tuple = AnimalParams();
			float height = tuple.Item1;
			float weight = tuple.Item2;
			string eyeColor = tuple.Item3;


			NotificationService.Write("Введите имя: ");
			string name = ReaderService.ReadLine();
			NotificationService.Write("Введите породу:");
			string breed = ReaderService.ReadLine();

			NotificationService.Write("Введите цвет шерсти: ");
			string coatColor = ReaderService.ReadLine();

			bool isItVaccinated = BoolEnter("У нее есть прививки?");
			DateTime birthDate = (DateTime)DateEnter("Введите дату рождения");

			bool isItTrained = BoolEnter("Собака тренированная?");
			return new Dog(height, weight, eyeColor, name, breed, isItVaccinated, coatColor, birthDate, isItTrained, SoundService);
		}
	}
}
