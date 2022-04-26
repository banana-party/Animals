﻿using Animals.Core.Business.Bases;
using Animals.Core.Interfaces;
using System;

namespace Animals.Core.Business.Instances
{
	public class Dog : HomeAnimalBase
    {
        #region Properties

        private bool _isItTrained = false;

        public bool IsItTrained
        {
            get => _isItTrained;
            private set
            {
                _isItTrained = value;
                OnPropertyChanged();
            }
        } 

        #endregion

        public Dog(IMakeASoundable sound, IDialogService dialog) : base(sound, dialog)
        {
        }

		public void Train()
		{
            if (IsItTrained)
            {
                DialogService.ShowMessage("Уже натренировано, больше некуда.", "Тренировка");
                return;
            }
			IsItTrained = true;
            DialogService.ShowMessage("Собака натренирована успешно.", "Тренировка");
        }
        //метод можно было реализовать лучше
		public override string ToString()
		{
			return $"{base.ToString()},{IsItTrained}";
		}
	}
}
