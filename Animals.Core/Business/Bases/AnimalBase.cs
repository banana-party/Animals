using System;
using System.ComponentModel;
using Animals.Core.Exctensions;
using Animals.Core.Interfaces;
using System.Globalization;
using System.Runtime.CompilerServices;
using Animals.Core.Annotations;

namespace Animals.Core.Business.Bases
{
	public abstract class AnimalBase : IAnimal, INotifyPropertyChanged
    {     
        protected IMakeASoundable ASound;
        protected IDialogService DialogService;
        protected AnimalBase(IMakeASoundable aSound, IDialogService dialog)
        {
            ASound = aSound;
            DialogService = dialog;
        }

        #region Properties

        private float _height;

        public float Height
        {
            get => _height;
            set
            {
                _height = value;
                OnPropertyChanged();
            }
        }
        private float _weight;
        public float Weight
        {
            get => _weight;
            set
            {
                _weight = value;
                OnPropertyChanged();
            }
        }
        private string _eyeColor;
        public string EyeColor
        {
            get => _eyeColor;
            set
            {
                _eyeColor = value;
                OnPropertyChanged();
            }
        }

        #endregion

        public void MakeASound()
        {
            ASound?.MakeASound();
        }
		public override string ToString()
		{
			return $"{this.Type()},{Height.ToString(CultureInfo.InvariantCulture)},{Weight.ToString(CultureInfo.InvariantCulture)},{EyeColor}";
		}

        public object Clone()
        {
            return MemberwiseClone();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}