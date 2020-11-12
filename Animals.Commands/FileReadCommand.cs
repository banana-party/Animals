using Animals.Commands.Bases;
using Animals.Core.Business;
using Animals.Core.Interfaces;
namespace Animals.Commands
{
    public class FileReadCommand : NotificationAndReaderCommandBase
	{

		public FileReadCommand(Zoo zoo, INotificationService notificationService, IReaderService readerService) : base(zoo, notificationService, readerService)
		{
		}

		public override void Execute()
		{
			NotificationService.Write("Введите путь к файлу (пустая строка означает путь по умолчанию): \n");
			string text = ReaderService.ReadLine();
			if (!string.IsNullOrEmpty(text))
			{
				//Если строка пустая, то открыть стандартный путь, иначе изменить путь на тот который ввел пользователь
				//Zoo.Open(path);
            }
			Zoo.ReadFromFile();
		}
		public override string ToString()
		{
			return "Прочитать зоопарк из файла.";
		}
	}
}
