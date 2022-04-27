using System;
using System.Reflection;
using System.Windows;
using System.Windows.Media;
using Animals.WPF.Services;

namespace Animals.WPF.Views
{
    public partial class MainWindowView : Window
    {
        public MainWindowView()
        {
            InitializeComponent();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            if (sender is CustomButton a)
                a.RandomBgColor = PickRandomBrush();
        }
        private static Brush PickRandomBrush()
        {
            Brush result = Brushes.Transparent;

            Random rnd = new Random();

            Type brushesType = typeof(Brushes);

            PropertyInfo[] properties = brushesType.GetProperties();

            int random = rnd.Next(properties.Length);
            result = (Brush)properties[random].GetValue(null, null);

            return result;
        }
    }
}
