using System;
using Animals.Core.Interfaces;
using System.Windows;
using System.Windows.Controls;
using Animals.WPF.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace Animals.WPF.Controls
{
    public partial class AnimalEditor : UserControl
    {
        private readonly IDialogService _dialogService = App.ServiceProvider.GetService<IDialogService>() ?? throw new NullReferenceException();
        public AnimalEditor()
        {
            InitializeComponent();
        }

        #region DependencyProperty

        public IAnimal Animal
        {
            get => (IAnimal)GetValue(AnimalProperty);
            set => SetValue(AnimalProperty, value);
        }

        public static readonly DependencyProperty AnimalProperty =
            DependencyProperty.Register("Animal", typeof(IAnimal), typeof(AnimalEditor), new PropertyMetadata(null, OnAnimalChanged));

        #endregion

        #region Methods
        private static void OnAnimalChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var type = e.NewValue.GetType();
            if (d is not AnimalEditor control)
                return;
            control.Animal = e.NewValue as IAnimal;
            control.PropertyEditor.SetGrid(control.Animal);
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
                ((EditAnimalViewModel)DataContext).SelectedAnimal = Animal;
                window.Close();
            }
        }

        private void Cancel(object sender, RoutedEventArgs e)
        {
            var t = Window.GetWindow(this);
            if (t is not null)
            {
                t.DialogResult = false;
                t.Close();
            }
        }

        #endregion
    }
}
