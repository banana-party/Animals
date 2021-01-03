using Animals.Core.Interfaces;

namespace Animals.Commands
{
	public class ExitCommand : ICommand
	{
		public void Execute()
		{
		}
		public override string ToString() => "Выход";
	}
}
