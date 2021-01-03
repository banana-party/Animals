using Amimals.WPF.Commands;
using Animals.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
