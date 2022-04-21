using Animals.Core.Interfaces;

namespace Animals.Core.Business.Bases
{
	public abstract class BirdBase : AnimalBase
    {
        #region Properties

        private int _flyHeight;
        public int FlyHeight
        {
            get => _flyHeight;
            set
            {
                _flyHeight = value;
                OnPropertyChanged();
            }
        }

        #endregion

        protected BirdBase() : base()
        {
        }
		protected BirdBase(float height, float weight, string eyeColor, int flyHeight, IMakeASoundable aSound) : base( height, weight, eyeColor, aSound)
		{
			FlyHeight = flyHeight;
		}
		
        //TODO: Реализовать вызов метода
		public string Fly()
		{
			return $"Я лечу на высоте {FlyHeight} метров!";
		}
		
		public override string ToString()
		{
			return $"{base.ToString()},{FlyHeight}";
		}
	}
}

