using Amimals.WPF.Commands;
using Amimals.WPF.Services;
using Animals.Core.Business.Instances;
using Animals.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amimals.WPF.ViewModels
{
	class MainWindowViewModel : BaseViewModel
	{
		private List<IAnimal> _animals;
		public List<IAnimal> Animals
		{
			get => _animals;
			set
			{
				_animals = value;
				NotifyOfPropertyChanged("Animals");
			}
		}
		public MainWindowViewModel()
		{
			Animals = new List<IAnimal>()
			{
				new Chicken(new SoundService(), new NotificationService(), 12.2f, 13.3f, "Red", 0)
			};
		}
		public Command AddCommand => new Command(Add);
		public void Add()
		{ 
		}
		public Command EditCommand => new Command(Edit);
		public void Edit()
		{
		}
		public Command RemoveCommand => new Command(Remove);
		public void Remove()
		{
		}

	}
}
