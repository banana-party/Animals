using Animals.Console.Commands.Bases;
using Animals.Console.Commands.Extensions;
using Animals.Core.Business;
using Animals.Core.Interfaces;

namespace Animals.Console.Commands
{
    public class DeleteAnimalCommand : DialogAndReaderCommandBase
	{
		public DeleteAnimalCommand(Zoo zoo, IDialogService dialog, IReaderService readerService) : base(zoo, dialog, readerService)
		{
		}
		//Метод можно было написать лучше
		public override void Execute()
		{
			//Лучше использовать ?.
            //Нужно проверять индекс, который ввёл пользователь
			Zoo.RemoveAt(this.ReadIndex(DialogService, ReaderService));
		}
		//Метод можно было написать лучше
		public override string ToString()
		{
			return "Удалить животное из зоопарка.";
		}
	}
}
