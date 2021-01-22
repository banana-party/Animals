using System;
using System.Globalization;
using System.Windows.Data;
//Всё отлично
namespace Amimals.WPF.Converters
{
	class ValueToBoolConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture) =>value != null;

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
