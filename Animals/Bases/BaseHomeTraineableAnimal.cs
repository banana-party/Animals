using Animals.Core.Interfaces;

namespace Animals.Bases
{
	public abstract class BaseHomeTraineableAnimal : BaseHomeAnimal //тренировать можно не только собаку
	{
		private ITraineble _traineble;
		public bool IsItTrained { get; set; }
		public BaseHomeTraineableAnimal(ICareable careable, ISoundable soundable, ITraineble traineble) : base(careable, soundable)
		{
			_traineble = traineble;
		}
		public void Train()
		{
			_traineble.Train();
		}
	}
}
