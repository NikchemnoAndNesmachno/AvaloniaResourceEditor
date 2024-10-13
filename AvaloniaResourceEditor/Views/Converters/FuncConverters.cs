using System.IO;
using Avalonia.Data.Converters;

namespace AvaloniaResourceEditor.Views.Converters;

public static class FuncConverters
{
    public static FuncValueConverter<string, string> PathToFileNameConverter =>
        new(path => path is null ? "" : new FileInfo(path).Name);
}