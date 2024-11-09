using System;
using System.Globalization;
using System.Windows.Data;

namespace WpfApp1.Converters
{
    public class ItemsPathConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null || parameter == null) return null;
            var propertyPath = parameter.ToString();
            var property = value.GetType().GetProperty(propertyPath);
            return property?.GetValue(value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
} 