using Animals.Core.Business.Bases;
using Animals.Core.Interfaces;
using System;

namespace Animals.Core.Business.Instances
{
	public class Wolf : WildAnimalBase
    {
        public Wolf(IMakeASoundable sound, IDialogService dialog) : base(sound, dialog)
        {
        }

        #region Properties

        private bool _isItAlpha = false;
        public bool IsItAlpha
        {
            get => _isItAlpha;
            set
            {
                _isItAlpha = value;
                OnPropertyChanged();
            }
        }

        #endregion

       
        //Метод можно было реализовать лучше
		public override string ToString()
		{
			return $"{base.ToString()},{IsItAlpha}";
		}
	}

}
