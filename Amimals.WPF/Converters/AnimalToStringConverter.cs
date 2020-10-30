using System;
using System.Globalization;
using System.Windows.Data;

namespace Amimals.WPF.Converters
{
	class AnimalToStringConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return targetType.ToString();
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
