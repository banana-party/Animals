using System;
using Animals.Core.Business.Instances;
using Animals.Core.Interfaces;
using System.Collections.ObjectModel;
using Animals.Core.Constants;
using Animals.WPF.Commands;
using Animals.WPF.Services;
using Animals.WPF.Services.Creators;
using Animals.WPF.Views;
using Microsoft.Extensions.DependencyInjection;

namespace Animals.WPF.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        private readonly IDialogService _dialogService = App.ServiceProvider.GetService<IDialogService>() ?? throw new NullReferenceException();
        private readonly WpfFactory _factory = WpfFactory.CreateFactory();

        public MainWindowViewModel()
        {
            var chicken = _factory.CreateAnimal("Chicken");
            chicken.EyeColor = "Red";
            chicken.Height = 12.2f;
            chicken.Weight = 13.3f;
            if (chicken is Chicken c)
                c.FlyHeight = 0;
            

            Animals = new ObservableCollection<IAnimal>()
            {
                chicken,
                new Cat
                (
                     12f, 44f,
                    "Green", "Vasya", "Tasmanian", true,
                    "Black", new System.DateTime(1332, 11, 3),
                    true, new SoundService(Consts.GetCatSoundPath)
                ),
                new Dog
                (
                    12.2f,33f,
                    "Yellow", "Boobick", "Street", false,
                    "Brown", new System.DateTime(2015,3,24),
                    false, new SoundService(Consts.GetDogSoundPath)
                ),
                new Stork(11.1f,22,"Black", 200, new SoundService(Consts.GetStorkSoundPath))
            };
        }

        #region Properties

        private ObservableCollection<IAnimal> _animals;
        public ObservableCollection<IAnimal> Animals
        {
            get => _animals;
            set
            {
                _animals = value;
                OnPropertyChanged();
            }
        }
        private IAnimal _selectedAnimal;
        public IAnimal SelectedAnimal
        {
            get => _selectedAnimal;
            set
            {
                _selectedAnimal = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Commands
        public Command AddCommand => new Command(Add);
        public void Add()
        {
            var view = App.ServiceProvider.GetRequiredService<AddAnimalView>();
            
            if ((bool) view.ShowDialog())
            {
                Animals.Add(((AddAnimalViewModel) view.DataContext).Animal);
            }
        }
        public Command EditCommand => new Command(Edit);
        public void Edit()
        {
            var animal = (IAnimal)SelectedAnimal.Clone();
            var view = App.ServiceProvider.GetRequiredService<EditAnimalView>();
            ((EditAnimalViewModel) view.DataContext).SelectedAnimal = animal;

            if ((bool)view.ShowDialog())
            {
                var i = Animals.IndexOf(SelectedAnimal);
                Animals.RemoveAt(i);
                Animals.Insert(i, (IAnimal)((EditAnimalViewModel)view.DataContext).SelectedAnimal.Clone());
            }
            else
                SelectedAnimal = null;
            
        }

        public Command RemoveCommand => new Command(Remove);
        public void Remove()
        {
            if (!_dialogService.ShowYesNoDialog("Вы действительно хотите удалить это животное?", "Удаление"))
                return;
            Animals.Remove(SelectedAnimal);
            SelectedAnimal = null;
        }
        public Command PlaySoundCommand => new Command(PlaySound);
        private void PlaySound()
        {
            SelectedAnimal.MakeASound();
        }

        #endregion

    }
}
