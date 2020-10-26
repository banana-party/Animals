using Animals.Buisness;
using Animals.Commands.Bases;
using Animals.Core.Interfaces;

namespace Animals.Commands
{
	public class AnimalMakeSoundCommand : NotificationCommandBase
	{
		public AnimalMakeSoundCommand(Zoo zoo, IReaderService readerService, INotificationService notificationService) : base(zoo, readerService, notificationService)
		{
		}

		public override void Execute()
		{
			_notificationService.Write("Введите индекс животного, которое должно издать звук: ");
			int index;	
			while (!int.TryParse(_readerService.ReadLine(), out index))
			{
				_notificationService.WriteLine("Неверный ввод.");
				_notificationService.Write("Введите индекс животного, которое должно издать звук: ");
			}
			_zoo.MakeASound(index);
		}
		public override string ToString()
		{
			return "Заставить животное с номером i издать звук.";
		}
	}
}
