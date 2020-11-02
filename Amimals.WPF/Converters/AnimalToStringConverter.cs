using System;
using System.Globalization;
using System.Windows.Data;

namespace Amimals.WPF.Converters
{
	class AnimalToStringConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			/*Необходимо проводить проверки на принимаемое значение и его тип, так же не надо вызывать ToString у принимаемого типа,
                Это бесполезно и непонятно для пользователя			 
			 */

			return targetType.ToString();
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
