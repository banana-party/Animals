﻿using Animals.Commands.Bases;
using Animals.Core.Business;

namespace Animals.Commands
{
	public class AllAnimalMakeSoundCommand : CommandBase
	{
		public AllAnimalMakeSoundCommand(Zoo zoo) : base(zoo)
		{
		}

		public override void Execute()
		{
			_zoo.MakeASound();
		}
		public override string ToString()
		{
			return "Заставить всех животных в зоопарке издать звук.";
		}
	}
}
