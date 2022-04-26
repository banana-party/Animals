using Animals.Console.Commands.Bases;
using Animals.Core.Interfaces;

namespace Animals.Console.Commands.Extensions
{
    public static class CommandBaseExtension
	{
		public static int ReadIndex(this CommandBase command, IDialogService dialogService, IReaderService readerService)
		{
			dialogService.ShowMessage("Введите номер животного: ");
			int index;
			while (!int.TryParse(readerService.ReadLine(), out index))
			{
				dialogService.ShowMessage("Неверный ввод.\n");
				dialogService.ShowMessage("Введите индекс животного: ");
			}
			return --index;
		}
	}
}
