using System;
using System.Globalization;
using Xamarin.Forms;

namespace CT
{
	public class StatusColorConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			Color statusColor = Color.White;

			if (value is int)
			{
				switch ((int)value)
				{
					case 0:
						statusColor = Color.Lime;
						break;

					case 1:
						statusColor = Color.Yellow;
						break;

					case 2:
						statusColor = Color.Red;
						break;

					default:
						statusColor = Color.Gray;
						break;
				}
			}

			return statusColor;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
