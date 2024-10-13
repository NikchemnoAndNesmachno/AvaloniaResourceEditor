using System;
using System.Globalization;
using Avalonia.Data.Converters;
using Avalonia.Media;

namespace AvaloniaResourceEditor.Views.Converters;

public class ColorConverter: IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if(value is string hex && !string.IsNullOrEmpty(hex)) return Color.Parse(hex);
        return Colors.Cyan;
        
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is Color color) return color.ToString();
        return "";
    }
}