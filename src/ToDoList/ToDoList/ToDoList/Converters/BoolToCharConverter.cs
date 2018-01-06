using System;
using System.Globalization;
using Xamarin.Forms;

namespace ToDoList.Converters
{
    public class BoolToCharConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is bool))
            {
                throw new InvalidOperationException("The target must be a boolean");
            }
            if ((bool)value)
            {
                return "v";
            }
            return "x";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
