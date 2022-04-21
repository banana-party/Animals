using System.ComponentModel;
using System.Windows;
using Animals.Core.Interfaces;

namespace Animals.WPF.ViewModels
{
    public class AddAnimalViewModel : BaseViewModel
    {
        private IAnimal _animal;

        public IAnimal Animal
        {
            get => _animal;
            set
            {
                _animal = value;
                OnPropertyChanged();
            }
        }
    }
}
