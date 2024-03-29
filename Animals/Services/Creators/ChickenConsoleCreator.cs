﻿using Animals.Core.Business.Instances;
using Animals.Core.Interfaces;
//Всё нормально
namespace Animals.Console.Services.Creators
{
	public class ChickenConsoleCreator : BaseAnimalConsoleCreator
	{
		public ChickenConsoleCreator(IReaderService readerService, IDialogService dialog) : base(readerService, dialog)
		{
			SoundService = ConsoleSoundService.CreateSoundService("Пок-пок-пок");
		}

		public override IAnimal Create()
		{
			var tuple = AnimalParams();
			float height = tuple.Item1;
			float weight = tuple.Item2;
			string eyeColor = tuple.Item3;

			return new Chicken(SoundService, DialogService);
		}
	}
}
