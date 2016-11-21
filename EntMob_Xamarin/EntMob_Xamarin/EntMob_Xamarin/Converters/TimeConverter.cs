using System;
using System.Globalization;
using Xamarin.Forms;

namespace EntMob_Xamarin.Converters
{
	public class TimeConverter: IValueConverter
	{

		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value != null)
			{
				DateTime time = (DateTime)value;
				return time.ToString("HH:mm:ss");
			}
			return value;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
