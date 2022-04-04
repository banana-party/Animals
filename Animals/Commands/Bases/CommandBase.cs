using Animals.Core.Business;
using Animals.Core.Interfaces;

namespace Animals.Console.Commands.Bases
{
	public abstract class CommandBase : ICommand
	{
		protected Zoo Zoo;
		protected CommandBase(Zoo zoo)
		{
			Zoo = zoo;
		}
		public abstract void Execute();
	}
}
