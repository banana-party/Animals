using Animals.Core.Business.Bases;
using Animals.Core.Interfaces;
using System;

namespace Animals.Core.Business.Instances
{
	public class Wolf : WildAnimalBase
    {
        #region Properties

        private bool _isItAlpha;
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

		public Wolf(float height, float weight, string eyeColor, string habitat, DateTime dateOfFind, bool isItAlpha, IMakeASoundable aSound) 
			: base(height, weight, eyeColor, habitat, dateOfFind, aSound)
		{
			IsItAlpha = isItAlpha;
		}
        //Метод можно было реализовать лучше
		public override string ToString()
		{
			return $"{base.ToString()},{IsItAlpha}";
		}
	}

}
