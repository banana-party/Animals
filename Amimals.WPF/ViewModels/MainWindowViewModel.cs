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

using ICommand = System.Windows.Input.ICommand;

namespace Animals.WPF.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        private readonly IDialogService _dialogService = App.ServiceProvider.GetService<IDialogService>() ?? throw new NullReferenceException();

        public MainWindowViewModel()
        {
            //TODO: Данные для тестов. Удалить
            var factory = WpfFactory.CreateFactory(_dialogService);
            var chicken = factory.CreateAnimal(Consts.Chicken);
            chicken.EyeColor = "Red";
            chicken.Height = 12.2f;
            chicken.Weight = 13.3f;
            if (chicken is Chicken chick)
                chick.FlyHeight = 0;

            var cat = factory.CreateAnimal(Consts.Cat);
            cat.EyeColor = "Green";
            cat.Height = 12f;
            cat.Weight = 44f;
            if (cat is Cat kitty)
            {
                kitty.IsItWooled = true;
                kitty.Name = "Vasya";
                kitty.Breed = "Tasmanian";
                kitty.BirthDate = new DateTime(1332, 11, 3);
                kitty.CoatColor = "Black";
                kitty.IsItVaccinated = true;
            }

            var dog = factory.CreateAnimal(Consts.Dog);
            dog.EyeColor = "Yellow";
            dog.Height = 12.2f;
            dog.Weight = 33f;
            if (dog is Dog doggo)
            {
                doggo.Name = "Boobick";
                doggo.BirthDate = new DateTime(2015, 3, 24);
                doggo.CoatColor = "Brown";
                doggo.Breed = "Streety";
                doggo.EyeColor = "Yellow";
                doggo.IsItVaccinated = false;
            }

            var stork = factory.CreateAnimal(Consts.Stork);
            stork.EyeColor = "Black";
            stork.Height = 11.2f;
            stork.Weight = 22;
            if (stork is Stork s)
            {
                s.FlyHeight = 100;
            }

            Animals = new ObservableCollection<IAnimal>
            {
                chicken, cat, dog, stork
            };
        }

        #region Properties

        public ObservableCollection<IAnimal> Animals { get; set; }

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
        public ICommand AddCommand => new Command(Add);
        public void Add()
        {
            var view = App.ServiceProvider.GetRequiredService<AddAnimalView>();
            if (view is not null)
                if ((bool) view.ShowDialog())
                    Animals.Add(((AddAnimalViewModel) view.DataContext).Animal);
        }
        public ICommand EditCommand => new Command(Edit);
        public void Edit()
        {
            var animal = (IAnimal)SelectedAnimal.Clone();
            var view = App.ServiceProvider.GetRequiredService<EditAnimalView>();
            ((EditAnimalViewModel)view.DataContext).SelectedAnimal = animal;

            if ((bool)view.ShowDialog())
            {
                var i = Animals.IndexOf(SelectedAnimal);
                Animals.RemoveAt(i);
                Animals.Insert(i, (IAnimal)((EditAnimalViewModel)view.DataContext).SelectedAnimal.Clone());
            }
            else
                SelectedAnimal = null;
        }

        public ICommand RemoveCommand => new Command(Remove);
        public void Remove()
        {
            if (!_dialogService.ShowYesNoDialog("Вы действительно хотите удалить это животное?", "Удаление"))
                return;
            Animals.Remove(SelectedAnimal);
            SelectedAnimal = null;
        }
        public ICommand PlaySoundCommand => new Command(PlaySound);
        private void PlaySound()
        {
            SelectedAnimal.MakeASound();
        }

        #endregion
    }
}
