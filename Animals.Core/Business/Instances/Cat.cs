using Animals.Core.Business.Bases;
using Animals.Core.Interfaces;

namespace Animals.Core.Business.Instances
{
	public class Cat : HomeAnimalBase
	{
        public Cat(IMakeASoundable sound, IDialogService dialog) : base(sound, dialog)
        {
        }

        #region Properties

        private bool _isItWooled;
        public bool IsItWooled
        {
            get => _isItWooled;
            set
            {
                _isItWooled = value;
                OnPropertyChanged();
            }
        }

        #endregion

		public override string ToString()
		{
			return $"{base.ToString()},{IsItWooled}";
		}

	}
}
