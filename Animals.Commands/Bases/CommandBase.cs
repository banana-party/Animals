using Animals.Core.Interfaces;
using Animals.Buisness;

namespace Animals.Commands.Bases
{
	public abstract class CommandBase : ICommand
	{
		protected readonly Zoo _zoo;
		protected CommandBase(Zoo zoo)
		{
			_zoo = zoo;
		}
		public abstract void Execute();
	}
}
