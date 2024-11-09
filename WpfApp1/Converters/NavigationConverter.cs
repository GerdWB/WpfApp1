using System;
using System.Globalization;
using System.Windows.Data;

namespace WpfApp1.Converters;

public class NavigationConverter : IMultiValueConverter
{
    public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
    {
        if (values is not [int currentStep, int maxSteps])
            return null;

        return currentStep;
    }

    public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}