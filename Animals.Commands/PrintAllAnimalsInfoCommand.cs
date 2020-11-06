using Animals.Commands.Bases;
using Animals.Core.Business;
//Всё отлично
namespace Animals.Commands
{
	public class PrintAllAnimalsInfoCommand : CommandBase
	{
		public PrintAllAnimalsInfoCommand(Zoo zoo) : base(zoo)
		{
		}

		public override void Execute()
		{
			_zoo.PrintInfo();
		}
		public override string ToString()
		{
			return "Напечатать информацию о животных, которые есть на данный момент в зоопарке.";
		}
	}
}
