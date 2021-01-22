using Animals.Commands.Bases;
using Animals.Core.Interfaces;
//Отлично написанный класс
namespace Animals.Commands.Extensions
{
    public static class CommandBaseExtension
	{
		public static int ReadIndex(this CommandBase command, INotificationService notificationService, IReaderService readerService)
		{
			notificationService.Write("Введите номер животного: ");
			int index;
			while (!int.TryParse(readerService.ReadLine(), out index))
			{
				notificationService.Write("Неверный ввод.\n");
				notificationService.Write("Введите индекс животного: ");
			}
			return --index;
		}
	}
}
