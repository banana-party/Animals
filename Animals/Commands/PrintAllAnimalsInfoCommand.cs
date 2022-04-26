using System.Linq;
using Animals.Console.Commands.Bases;
using Animals.Core.Business;
using Animals.Core.Interfaces;

namespace Animals.Console.Commands

{
	public class PrintAllAnimalsInfoCommand : DialogCommandBase
	{
		public PrintAllAnimalsInfoCommand(Zoo zoo, IDialogService dialogService) : base(zoo, dialogService)
		{
		}

		public override void Execute() //TODO: вывод на экран в консоли выглядит убого.
		{
            var lst = Zoo.Info().Select(a => a.ToString().Split(','));

            int count = 1;
			foreach (var el in lst)
			{
				DialogService.ShowMessage($"{count++}. {el[0]}:\n\t");
                foreach (var e in el)
                    DialogService.ShowMessage($"{e} ");
                DialogService.ShowMessage($"\n");
			}
		}
        //Метод можно было реализовать лучше
		public override string ToString()
		{
			return "Напечатать информацию о животных, которые есть на данный момент в зоопарке.";
		}
	}
}
