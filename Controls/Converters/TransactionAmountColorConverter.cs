using System;
using System.Collections.Generic;
using System.Globalization;
using Avalonia.Data.Converters;
using Avalonia.Media;
using BankSystem.Models.Structures;
using BankSystem.Services;

namespace BankSystem.Controls.Converters;

public class TransactionAmountColorConverter : IMultiValueConverter
{
    public object Convert(IList<object> values, Type targetType, object parameter, CultureInfo culture)
    {
        if (values.Count == 2 && values[0] is DetailTransaction transaction && values[1] is int currentAccountId)
        {
            if (transaction.SenderAccountID == currentAccountId)
            {
                return Brushes.Crimson;
            }
            else
            {
                return Brushes.LightGreen;
            }
        }
        return Brushes.White;
    }

    public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}