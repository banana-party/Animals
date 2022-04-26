using Animals.Core.Business.Instances;
using Animals.Core.Interfaces;
using System;
//Дублирование кода с CatConsoleCreator, нужно использовать базовый класс домашних животных для предотвращения этого
namespace Animals.Console.Services.Creators
{
	public class DogConsoleCreator : BaseAnimalConsoleCreator
	{
		public DogConsoleCreator(IReaderService readerService, IDialogService dialog) : base(readerService, dialog)
		{
			SoundService = ConsoleSoundService.CreateSoundService("ГАВ");
		}

		public override IAnimal Create()
		{
			var tuple = AnimalParams();
			float height = tuple.Item1;
			float weight = tuple.Item2;
			string eyeColor = tuple.Item3;

            //Избавиться от дублирования кода
            DialogService.ShowMessage("Введите имя: ");
			string name = ReaderService.ReadLine();
            DialogService.ShowMessage("Введите породу:");
			string breed = ReaderService.ReadLine();

            DialogService.ShowMessage("Введите цвет шерсти: ");
			string coatColor = ReaderService.ReadLine();

			bool isItVaccinated = BoolEnter("У нее есть прививки?");
			DateTime birthDate = (DateTime)DateEnter("Введите дату рождения");

			bool isItTrained = BoolEnter("Собака тренированная?");
			return new Dog(SoundService, DialogService);
		}
	}
}
