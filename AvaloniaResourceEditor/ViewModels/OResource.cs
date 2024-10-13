using System.Collections.Generic;
using System.Collections.ObjectModel;
using AvaloniaResourceEditor.Models;
using CommunityToolkit.Mvvm.ComponentModel;

namespace AvaloniaResourceEditor.ViewModels;

public partial class OResource: ViewModelBase, IResource
{
    [ObservableProperty] private string _name = "";
    public IList<ITagValue> Values { get; set; } = new ObservableCollection<ITagValue>();

    public ITagValue Create()
    {
        var tagValue = new OTagValue();
        Values.Add(tagValue);
        return tagValue;
    }
    
}