using Animals.Core.Interfaces;
using Animals.Core.Business;

namespace Animals.Commands.Bases
{
	public abstract class CommandBase : ICommand
	{
		//Лучше было назвать поле Zoo
		protected Zoo _zoo;
		protected CommandBase(Zoo zoo)
		{
			_zoo = zoo;
		}
		public abstract void Execute();
	}
}
