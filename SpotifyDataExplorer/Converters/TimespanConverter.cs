using System;
using System.Globalization;
using Avalonia.Data;
using Avalonia.Data.Converters;

namespace SpotifyDataExplorer.Converters;

public class TimespanConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is TimeSpan timespan)
        {
            return timespan.Hours == 0 ? $@"{timespan:m\:ss}" : $@"{timespan:hh\:mm\:ss}";
        }

        return new BindingNotification(new InvalidCastException(), BindingErrorType.Error);
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        return null;
    }
}