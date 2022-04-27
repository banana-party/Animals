using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Animals.Core.Interfaces;
using Animals.WPF.Helpers;
using Animals.WPF.Services.Creators;
using Animals.WPF.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace Animals.WPF.Controls
{
    public partial class AnimalAdd : UserControl
    {
        private readonly IDialogService _dialogService = App.ServiceProvider.GetRequiredService<IDialogService>() ?? throw new NullReferenceException();
        private class Item
        {
            public string DisplayName { get; set; }
            public IAnimal Animal { get; set; }
        }

        public IAnimal Animal
        {
            get => (IAnimal)GetValue(AnimalProperty);
            set => SetValue(AnimalProperty, value);
        }

        public static readonly DependencyProperty AnimalProperty =
            DependencyProperty.Register("Animal", typeof(IAnimal), typeof(AnimalAdd), new PropertyMetadata(null, OnAnimalChanged));

        public AnimalAdd()
        {
            InitializeComponent();
            var factory = WpfFactory.CreateFactory(_dialogService);

            ChooseAnimalComboBox.ItemsSource = AnimalTypesHelper.GetAnimalTypes()
                .Select(item => new Item
                {
                    DisplayName = item.Name,
                    Animal = factory.CreateAnimal(item.Name)
                });
        }

        #region Methods

        private static void OnAnimalChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is not AnimalAdd control)
                return;
            control.PropertyEditor.SetGrid(control.Animal);
        }
        private void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender is ComboBox c)
            {
                Animal = ((Item)c.SelectedItem).Animal;
            }
        }

        private void Save(object sender, RoutedEventArgs e)
        {
            var window = Window.GetWindow(this);
            if (window is not null)
            {
                if (PropertyEditor.CheckFields(out var errorFieldNames))
                {
                    _dialogService.ShowErrorDialog($"{string.Join(", ", errorFieldNames)} has not proper values.", "Error");
                    return;
                }
                window.DialogResult = true;
                ((AnimalViewModel)DataContext).Animal = Animal;
                window.Close();
            }
        }

        private void Cancel(object sender, RoutedEventArgs e)
        {
            var window = Window.GetWindow(this);
            if (window is not null)
            {
                window.DialogResult = false;
                window.Close();
            }
        }

        #endregion
    }
}
