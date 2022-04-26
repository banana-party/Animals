using Animals.Core.Business;
using Animals.Core.Interfaces;

namespace Animals.Console.Commands.Bases
{
	public abstract class DialogAndReaderCommandBase : DialogCommandBase
	{
		protected readonly IReaderService ReaderService;

		protected DialogAndReaderCommandBase(Zoo zoo, IDialogService dialog, IReaderService readerService) : base(zoo, dialog)
		{
			ReaderService = readerService;
		}
    }
}
