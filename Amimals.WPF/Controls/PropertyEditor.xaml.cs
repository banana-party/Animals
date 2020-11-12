using Animals.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Amimals.WPF.Controls
{
	/// <summary>
	/// Логика взаимодействия для PropertyEditor.xaml
	/// </summary>
	public partial class PropertyEditor : UserControl
	{
		public IAnimal Animal
		{
			get { return (IAnimal)GetValue(AnimalProperty); }
			set { SetValue(AnimalProperty, value); }
		}

		// Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
		public static readonly DependencyProperty AnimalProperty =
			DependencyProperty.Register("Animal", typeof(IAnimal), typeof(PropertyEditor), new PropertyMetadata(null, AnimalChanged));

		private static void AnimalChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
            var type = e.NewValue.GetType();
            if (!(d is PropertyEditor))
                return;
            var control = d as PropertyEditor;
            control.Animal = e.NewValue as IAnimal;
            var grid = control.PropertyGrid;
            grid.Children.Clear();
            grid.RowDefinitions.Clear();
            int i = 0;
            foreach (var property in type.GetProperties())
            {
                grid.RowDefinitions.Add(new RowDefinition()
                {
                    Height = GridLength.Auto
                });
                TextBlock textBlock = new TextBlock()
                {
                    Text = property.Name
                };
                Grid.SetRow(textBlock, i);
                Grid.SetColumn(textBlock, 0);
                grid.Children.Add(textBlock);
                Control userControl = new TextBox();
                DependencyProperty dp = TextBox.TextProperty;
                if (property.PropertyType == typeof(DateTime))
                {
                    userControl = new DatePicker();
                    dp = DatePicker.SelectedDateProperty;
                }

                BindingBase binding = new Binding()
                {
                    Path = new PropertyPath(property.Name),
                    Mode = property.CanWrite ? BindingMode.TwoWay : BindingMode.OneWay
                };
                BindingOperations.SetBinding(userControl, dp, binding);
                Grid.SetRow(userControl, i);
                Grid.SetColumn(userControl, 1);
                grid.Children.Add(userControl);
                i++;
            }
        }

		public PropertyEditor()
		{
			InitializeComponent();
		}
	}
}
