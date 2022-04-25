using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using Animals.Core.Annotations;
using Animals.Core.Interfaces;

namespace Animals.WPF.Controls
{
    /// <summary>
    /// Interaction logic for AnimalCard.xaml
    /// </summary>
    public partial class AnimalCard : UserControl, INotifyPropertyChanged
    {
        public AnimalCard()
        {
            InitializeComponent();
        }
        
        public IAnimal Animal
        {
            get => (IAnimal)GetValue(AnimalProperty);
            set => SetValue(AnimalProperty, value);
        }

        private string _animalName;

        public string AnimalName
        {
            get => _animalName;
            set
            {
                _animalName = value;
                OnPropertyChanged();
            }
        }

        public static readonly DependencyProperty AnimalProperty =
            DependencyProperty.Register("Animal", typeof(IAnimal), typeof(AnimalCard), new PropertyMetadata(null, SetGrid));

        private static void SetGrid(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var type = e.NewValue?.GetType();
            if (d is not AnimalCard control)
                return;
            control.Animal = e.NewValue as IAnimal;
            control.PropertyEditor.SetGrid(control.Animal, true);
        }

        private void AnimalCard_OnDataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            Animal = (IAnimal)DataContext;
            AnimalName = Animal.GetType().Name;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
