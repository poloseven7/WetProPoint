using System;
using System.Windows;
using System.Windows.Data;

namespace WetProPoint
{
    [ValueConversion(typeof(bool), typeof(bool))]
    public class InverseBooleanConverter : IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter,
            System.Globalization.CultureInfo culture)
        {
            if ( (targetType != typeof(bool)) && (targetType != typeof(Visibility)))
                throw new InvalidOperationException("The target must be a boolean or visibility");


            if (targetType == typeof(Visibility))
            {
                return (Visibility)((bool)value ? Visibility.Collapsed : Visibility.Visible);
            }
            else
                return !(bool)value;
        }

        public object ConvertBack(object value, Type targetType, object parameter,
            System.Globalization.CultureInfo culture)
        {
            throw new NotSupportedException();
        }

        #endregion
    }
}