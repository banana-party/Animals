using Animals.Buisness;
using Animals.Commands.Bases;

namespace Animals.Commands
{
	public class AllAnimalMakeSoundCommand : CommandBase
	{
		public AllAnimalMakeSoundCommand(Zoo zoo) : base(zoo)
		{
		}

		public override void Execute()
		{
			_zoo.PrintInfo();
		}
		public override string ToString()
		{
			return "Заставить всех животных в зоопарке издать звук.";
		}
	}
}
