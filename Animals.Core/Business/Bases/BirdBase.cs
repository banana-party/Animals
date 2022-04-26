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

        protected BirdBase(IMakeASoundable sound, IDialogService dialog) : base(sound, dialog)
        {
        }

        //TODO: Реализовать вызов метода
		public void Fly()
        {
            DialogService.ShowMessage($"Я лечу на высоте {FlyHeight} метров!");
        }
		
		public override string ToString()
		{
			return $"{base.ToString()},{FlyHeight}";
		}
	}
}

