using Animals.Console.Commands.Bases;
using Animals.Core.Business;

namespace Animals.Console.Commands
{
	public class AllAnimalMakeSoundCommand : CommandBase
	{
		public AllAnimalMakeSoundCommand(Zoo zoo) : base(zoo)
		{
		}
		
		public override void Execute()
		{
			Zoo.MakeASound();
		}
        public override string ToString()
		{
			return "Заставить всех животных в зоопарке издать звук.";
		}
	}
}
