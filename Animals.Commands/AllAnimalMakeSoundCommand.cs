using Animals.Commands.Bases;
using Animals.Core.Business;
// всё отлично
namespace Animals.Commands
{
	public class AllAnimalMakeSoundCommand : CommandBase
	{
		public AllAnimalMakeSoundCommand(Zoo zoo) : base(zoo)
		{
		}
		//Можно было реализовать лучше
		public override void Execute()
		{
			Zoo.MakeASound();
		}
        //Можно было реализовать лучше
		public override string ToString()
		{
			return "Заставить всех животных в зоопарке издать звук.";
		}
	}
}
