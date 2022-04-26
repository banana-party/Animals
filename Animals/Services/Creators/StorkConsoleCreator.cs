using Animals.Core.Business.Instances;
using Animals.Core.Interfaces;
//Дублирование кода у всех птиц, надо постараться избавиться от дублирования кода
namespace Animals.Console.Services.Creators
{
	class StorkConsoleCreator : BaseAnimalConsoleCreator
	{
		public StorkConsoleCreator(IReaderService readerService, IDialogService dialog) : base(readerService, dialog)
		{
			SoundService = ConsoleSoundService.CreateSoundService("Вааа");
		}

		public override IAnimal Create()
		{
			var tuple = AnimalParams();
			float height = tuple.Item1;
			float weight = tuple.Item2;
			string eyeColor = tuple.Item3;

			return new Stork(SoundService, DialogService);
		}
	}
}
