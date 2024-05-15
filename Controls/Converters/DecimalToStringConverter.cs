using System;
using System.Globalization;
using Avalonia.Data.Converters;

namespace BankSystem.Controls.Converters
{
    public class DecimalToStringConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is decimal)
            {
                return ((decimal)value).ToString("F2");
            }
            
            return value;
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}