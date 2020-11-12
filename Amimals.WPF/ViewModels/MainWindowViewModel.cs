using Amimals.WPF.Commands;
using Amimals.WPF.Services;
using Amimals.WPF.Views;
using Animals.Core.Business.Instances;
using Animals.Core.Interfaces;
using System.Collections.Generic;

namespace Amimals.WPF.ViewModels
{
	//Реализовать добавление, удаление и редактирование животных в зоопарке
	class MainWindowViewModel : BaseViewModel
	{
		private readonly IDialogService _dialogService;
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
		public MainWindowViewModel(IDialogService dialogService)
		{
			_dialogService = dialogService;
			Animals = new List<IAnimal>()
			{
				new Chicken(new SoundService(), new NotificationService(), 12.2f, 13.3f, "Red", 0),
				new Chicken(new SoundService(), new NotificationService(), 12.2f, 13.3f, "Red", 0),
				new Chicken(new SoundService(), new NotificationService(), 12.2f, 13.3f, "Red", 0),
				new Chicken(new SoundService(), new NotificationService(), 12.2f, 13.3f, "Red", 0),
				new Cat
				(
					new SoundService(), 
					new NotificationService(), true, 12f, 44f, 
					"Green", "Vasya", "Tasmanian", true, 
					"Black", new System.DateTime(1332, 11, 3)
				)
			};
		}
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
		public Command AddCommand => new Command(Add);
		public void Add()
		{ 
		}
		public Command EditCommand => new Command(Edit);
		public void Edit()
		{
			EditAnimalView view = new EditAnimalView()
			{
				DataContext = new EditAnimalViewModel()
				{
					SelectedAnimal = SelectedAnimal
				}
			};
			view.ShowDialog();
		}
		
		public Command RemoveCommand => new Command(Remove);
		public void Remove()
		{
			if (!_dialogService.ShowYesNoDialog("Вы действительно хотите удалить это животное?", "Удаление"))
				return;
			Animals.Remove(SelectedAnimal);
			SelectedAnimal = null;
			Animals = new List<IAnimal>(Animals);
		}
	}
}
