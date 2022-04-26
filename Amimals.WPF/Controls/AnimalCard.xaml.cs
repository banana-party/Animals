using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using Animals.Core.Annotations;
using Animals.Core.Business.Bases;
using Animals.Core.Interfaces;

using Command = Animals.WPF.Commands.Command;

namespace Animals.WPF.Controls
{
    public partial class AnimalCard : UserControl, INotifyPropertyChanged
    {
        #region Constructor

        public AnimalCard()
        {
            InitializeComponent();
        }

        #endregion

        #region Properties

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

        #endregion

        #region Fields

        private static readonly MethodInfo[] BaseMethods = typeof(AnimalBase).GetMethods();
        
        #endregion

        #region Methods
        private static void SetGrid(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var type = e.NewValue?.GetType();
            if (d is not AnimalCard control)
                return;
            control.Animal = e.NewValue as IAnimal;
            control.PropertyEditor.SetGrid(control.Animal, true);

            control.SetButtons(type);
        }

        private void SetButtons(Type type)
        {
            var methods = type.GetMethods();

            var uniqueMethods = methods.Except(BaseMethods, new AnimalMethodsEqualityComaprer())
                .Where(x => !x.Name.StartsWith("get_") && !x.Name.StartsWith("set_"));
            int i = 0;

            foreach (var method in uniqueMethods)
            {
                ButtonsGrid.ColumnDefinitions.Add(new ColumnDefinition
                    {Width = new GridLength(1, GridUnitType.Star)});

                var d = (Action)method.CreateDelegate(typeof(Action), Animal);

                var button = new Button
                {
                    Content = method.Name,
                    Command = new Command(d)
                };

                Grid.SetColumn(button, i++);
                Grid.SetRow(button, 0);
                ButtonsGrid.Children.Add(button);
            }
        }

        private void AnimalCard_OnDataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            Animal = (IAnimal)DataContext;
            AnimalName = Animal.GetType().Name;
        }

        #endregion

        #region PropertyChangedInvocator

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        
        #endregion

        #region EuqalityComparer

        private class AnimalMethodsEqualityComaprer : IEqualityComparer<MethodInfo>
        {
            public bool Equals(MethodInfo x, MethodInfo y)
            {
                return x?.Name == y?.Name;
            }

            public int GetHashCode(MethodInfo obj)
            {
                return obj.Name.GetHashCode();
            }
        }
        #endregion

    }

}
