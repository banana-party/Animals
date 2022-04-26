using Animals.Core.Business.Instances;
using Animals.Core.Interfaces;
using System;
//Дублирование кода получения параметров из Tuple и разбора Tuple
namespace Animals.Console.Services.Creators
{
	class TigerConsoleCreator : BaseAnimalConsoleCreator
	{
		public TigerConsoleCreator(IReaderService readerService, IDialogService dialog) : base(readerService, dialog)
		{
			SoundService = ConsoleSoundService.CreateSoundService("РЯЯ");
		}

		public override IAnimal Create()
		{
			var tuple = AnimalParams();
			float height = tuple.Item1;
			float weight = tuple.Item2;
			string eyeColor = tuple.Item3;

			DialogService.ShowMessage("Введите среду обитания: ");
			string habitat = ReaderService.ReadLine();

			DateTime dateOfFind = (DateTime)DateEnter("Введите дату нахождения");

			return new Tiger(SoundService, DialogService);
		}
	}
}
