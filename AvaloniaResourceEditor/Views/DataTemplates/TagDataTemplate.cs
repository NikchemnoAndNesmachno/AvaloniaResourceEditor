using System.Collections.Generic;
using Avalonia.Controls;
using Avalonia.Controls.Templates;
using Avalonia.Metadata;
using AvaloniaResourceEditor.Models;
using AvaloniaResourceEditor.ViewModels;

namespace AvaloniaResourceEditor.Views.DataTemplates;

public class TagDataTemplate: IDataTemplate
{
    [Content] public Dictionary<string, IDataTemplate> Templates { get; set; } = [];
    public Control? Build(object? param)
    {
        if (param is not OTagValue tagValue) return null;
        if (tagValue.Type == "SolidColorBrush") return Templates["Color"].Build(param);
        if (tagValue.Type == "s:String") return Templates["String"].Build(param);
        return null;
    }

    public bool Match(object? data)
    {
        return data is ITagValue;
    }
}