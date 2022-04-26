using System.Linq;
using Animals.Console.Commands.Bases;
using Animals.Console.Commands.Extensions;
using Animals.Core.Business;
using Animals.Core.Interfaces;

namespace Animals.Console.Commands
{
	public class PrintAnimalInfoCommand : DialogAndReaderCommandBase
	{
		public PrintAnimalInfoCommand(Zoo zoo, IDialogService dialogService, IReaderService readerService) : base(zoo, dialogService, readerService)
		{
		}

		public override void Execute()
		{
			var lst = Zoo.Info(this.ReadIndex(DialogService, ReaderService)).Split(',').ToList();
            DialogService.ShowMessage($"{lst[0]}:\n\t");
			for (int i = 1; i < lst.Count; i++)
			{
                DialogService.ShowMessage($"{lst[i]} ");
			}
		}
		//Метод можно было реализовать лучше
		public override string ToString()
		{
			return "Посмотреть информацию о животном с номером i.";
		}
	}
}
