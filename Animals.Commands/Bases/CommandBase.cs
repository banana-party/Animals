using Animals.Core.Interfaces;
using Animals.Core.Business;

namespace Animals.Commands.Bases
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
