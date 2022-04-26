using Animals.Core.Interfaces;
using System;

namespace Animals.Core.Business.Bases
{
    public abstract class WildAnimalBase : AnimalBase
    {
        protected WildAnimalBase(IMakeASoundable sound, IDialogService dialog) : base(sound, dialog)
        {
        }

        #region Properties

        private string _habitat;

        public string Habitat
        {
            get => _habitat;
            set
            {
                _habitat = value;
                OnPropertyChanged();
            }
        }
        private DateTime _dateOfFind;
        public DateTime DateOfFind
        {
            get => _dateOfFind;
            set
            {
                _dateOfFind = value;
                OnPropertyChanged();
            }
        }

        #endregion

        //Метод можно было написать лучше
        public override string ToString()
        {
            return $"{base.ToString()},{Habitat},{DateOfFind.Day}.{DateOfFind.Month}.{DateOfFind.Year}";
        }
    }
}
