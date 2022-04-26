using Animals.Console.Commands.Bases;
using Animals.Console.Commands.Extensions;
using Animals.Core.Business;
using Animals.Core.Interfaces;

namespace Animals.Console.Commands
{
	public class AnimalMakeSoundCommand : DialogAndReaderCommandBase
	{
		public AnimalMakeSoundCommand(Zoo zoo, IDialogService dialog, IReaderService readerService) : base(zoo, dialog, readerService)
		{
		}
		
        public override void Execute()
		{
			//Лучше использовать ?.
			Zoo.MakeASound(this.ReadIndex(DialogService, ReaderService));
		}
		
		public override string ToString()
		{
			return "Заставить животное с номером i издать звук.";
		}
	}
}
