using System.Globalization;
using System.Windows.Data;

namespace WpfApp1.Converters;

public class TreeItemPropertyConverter : IMultiValueConverter
{
    public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
    {
        if (values.Length != 2 || values[0] == null || values[1] == null)
            return null;

        var item = values[0];
        var propertyPath = values[1].ToString();

        var property = item.GetType().GetProperty(propertyPath);
        return property?.GetValue(item)?.ToString();
    }

    public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}