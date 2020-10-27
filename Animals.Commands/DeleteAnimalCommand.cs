using Animals.Commands.Bases;
using Animals.Core.Business;
using Animals.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Animals.Commands
{
	public class DeleteAnimalCommand : NotificationCommandBase
	{
		public DeleteAnimalCommand(Zoo zoo, IReaderService readerService, INotificationService notificationService) : base(zoo, readerService, notificationService)
		{
		}

		public override void Execute()
		{
			_notificationService.Write("Введите индекс животного, которое хотите удалить: ");
			int index;
			while(!int.TryParse(_readerService.ReadLine(), out index))
			{
				_notificationService.WriteLine("Неверный ввод.");
				_notificationService.Write("Введите индекс животного, которое хотите удалить: ");
			}
			_zoo.RemoveAt(--index);
		}
		public override string ToString()
		{
			return "Удалить животное из зоопарка.";
		}
	}
}
