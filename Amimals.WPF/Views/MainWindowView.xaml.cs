using Animals.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
using Animals.WPF.Services;
using Animals.WPF.ViewModels;

namespace Animals.WPF.Views
{
	/// <summary>
	/// Логика взаимодействия для MainWindow.xaml
	/// </summary>
	public partial class MainWindowView : Window
	{
		public MainWindowView()
		{
			IDialogService dialogService = new DialogService();
			DataContext = new MainWindowViewModel(dialogService);
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
