using Animals.Core.Business;
using Animals.Core.Interfaces;

namespace Animals.Console.Commands.Bases
{
	public abstract class DialogCommandBase : CommandBase
	{
		protected readonly IDialogService DialogService;
		protected DialogCommandBase(Zoo zoo, IDialogService dialog) : base(zoo)
        {
            DialogService = dialog;
        }
	}
}
