using Animals.Core.Business.Instances;
using Animals.Core.Interfaces;
using System;
//Всё хорошо
namespace Animals.Console.Services.Creators
{
	public class CatConsoleCreator : BaseAnimalConsoleCreator
	{
		public CatConsoleCreator(IReaderService readerService, IDialogService dialog) : base(readerService, dialog)
		{
			SoundService = ConsoleSoundService.CreateSoundService("МЯЯУ");
		}

		public override IAnimal Create()
		{
			var tuple = AnimalParams();
			float height = tuple.Item1; float weight = tuple.Item2; string eyeColor = tuple.Item3;


			DialogService.ShowMessage("Введите имя: ");
			string name = ReaderService.ReadLine();
            DialogService.ShowMessage("Введите породу: ");
			string breed = ReaderService.ReadLine();

			bool isItWooled = BoolEnter("У нее есть шерсть?");

			string coatColor;
			if (isItWooled)
			{
                DialogService.ShowMessage("Введите цвет шерсти: ");
				coatColor = ReaderService.ReadLine();
			}
			else
				coatColor = "Шерсти нет";

			bool isItVaccinated = BoolEnter("У нее есть прививки?");
			DateTime birthDate = (DateTime)DateEnter("Введите дату рождения");
			return new Cat(SoundService, DialogService);
		}
	}
}
