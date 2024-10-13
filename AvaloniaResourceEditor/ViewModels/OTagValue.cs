using System;
using AvaloniaResourceEditor.Models;
using CommunityToolkit.Mvvm.ComponentModel;

namespace AvaloniaResourceEditor.ViewModels;

public partial class OTagValue: ViewModelBase, ITagValue
{
    [ObservableProperty] private string _type = "s:String";
    [ObservableProperty] private string _key ="";
    [ObservableProperty] private string _value = "";

    public ITagValue Copy() => new OTagValue()
    {
        Type = Type,
        Key = Key,
        Value = Value
    };
}