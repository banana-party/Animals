using Animals.Commands.Bases;
using Animals.Core.Business;
using Animals.Core.Interfaces;
namespace Animals.Commands
{
    class FileReadCommand : NotificationCommandBase
	{
		public FileReadCommand(Zoo zoo, IReaderService readerService, INotificationService notificationService) : base(zoo, readerService, notificationService)
		{
		}

		public override void Execute()
		{
			_notificationService.WriteLine("Введите путь к файлу (пустая строка означает путь по умолчанию): ");
			string text = _readerService.ReadLine();
			if (string.IsNullOrEmpty(text))
			{
                //непотнятна реализация в этом месте даже не понятны планы на реализацию
            }
			_zoo.ReadFromFile();
		}
		public override string ToString()
		{
			//метод всё же стоило переопределить правильно
			return "";
		}
	}
}
