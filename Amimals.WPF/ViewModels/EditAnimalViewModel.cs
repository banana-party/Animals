using Amimals.WPF.Commands;
using Animals.Core.Interfaces;
using System;
//Необходимо реализовать редактирование животного в WPF
namespace Amimals.WPF.ViewModels
{
	class EditAnimalViewModel : BaseViewModel
	{
		private IAnimal _selectedAnimal;
		public IAnimal SelectedAnimal
		{
			get => _selectedAnimal;
			set
			{
				_selectedAnimal = value;
				NotifyOfPropertyChanged("SelectedAnimal");
			}
		}
		public EditAnimalViewModel()
		{
		}
		public Command SaveCommand => new Command(Save);

		public void Save()
		{
			throw new NotImplementedException();
		}
		public Command CancelCommand => new Command(Cancel);

		public void Cancel()
		{
			throw new NotImplementedException();
		}
	}
}
