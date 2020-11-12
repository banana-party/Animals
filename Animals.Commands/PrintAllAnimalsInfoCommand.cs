using Animals.Commands.Bases;
using Animals.Core.Business;
using Animals.Core.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Animals.Commands
{
	public class PrintAllAnimalsInfoCommand : NotificationCommandBase
	{
		public PrintAllAnimalsInfoCommand(Zoo zoo, INotificationService notificationService) : base(zoo, notificationService)
		{
		}

		public override void Execute()
		{
			var arr = Zoo.Info().ToList();
			List<List<string>> lst = new List<List<string>>();
			for (int i = 0; i < arr.Count; i++)
				lst.Add(arr[i].Split(',').ToList());

			int count = 1;
			foreach (var el in lst)
			{
				NotificationService.Write($"{count++}. {el[0]}:\n\t");
				for (int i = 1; i < el.Count ; i++)
				{
					NotificationService.Write($"{el[i]} ");
				}
				NotificationService.Write($"\n");
			}
		}
		public override string ToString()
		{
			return "Напечатать информацию о животных, которые есть на данный момент в зоопарке.";
		}
	}
}
