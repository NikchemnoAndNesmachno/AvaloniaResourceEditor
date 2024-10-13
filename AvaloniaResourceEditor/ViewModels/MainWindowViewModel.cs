using System.Collections.ObjectModel;
using Avalonia.Remote.Protocol.Input;
using AvaloniaResourceEditor.Models;

namespace AvaloniaResourceEditor.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    public MainWindowViewModel(SelectFilesViewModel vm)
    {
        SelectFilesViewModel = vm;
        vm.OnConfirm = Read;
    }
    public SelectFilesViewModel SelectFilesViewModel { get; set; }
    public ObservableCollection<ITagValue> Keys { get; set; } = [];
    public ObservableCollection<IResource> Resources { get; set; } = [];

    public void Read()
    {
        Keys.Clear();
        Resources.Clear();
        foreach (var filePath in SelectFilesViewModel.SelectedFiles)
        {
            var resource = new OResource();
            resource.ReadResource(filePath);
            Resources.Add(resource);
        }
        if(Resources.Count == 0) return;
        foreach (var tag in Resources[0].Values)
        {
            Keys.Add(tag.Copy());
        }
    }

    public void RemoveResource(IResource obj) => Resources.Remove(obj);

    public void RemoveKey(object objKey)
    {
        if(objKey is not ITagValue key) return;
        var keyIndex = Keys.IndexOf(key);
        if(keyIndex == -1) return;
        Keys.RemoveAt(keyIndex);
        foreach (var resource in Resources)
        {
            resource.Values.RemoveAt(keyIndex);
        }
    }
    public void CreateResource()
    {
        var resource = new OResource();
        foreach (var t in Keys)
        {
            resource.Values.Add(t.Copy());
        }
        Resources.Add(resource);
    }
    public void DuplicateResource(IResource mainResource)
    {
        var resource = new OResource
        {
            Name = mainResource.Name + "1",
        };
        Resources.Add(resource);
        foreach (var value in mainResource.Values)
        {
            resource.Values.Add(value.Copy());
        }
    }

    public void AddKey(string type)
    {
        var tag = new OTagValue()
        {
            Type = type
        };
        Keys.Add(tag);
        foreach (var resource in Resources)
        {
            resource.Values.Add(tag.Copy());
        }
    }
    public void AddStringKey() => AddKey("s:String");
    public void AddBrushKey() => AddKey("SolidColorBrush");

    public void Save()
    {
        for (int i = 0; i < Keys.Count; i++)
        {
            foreach (var resource in Resources)
            {
                resource.Values[i].Key = Keys[i].Key;
            }    
        }
        
        var folder = SelectFilesViewModel.Folder;
        foreach (var resource in Resources)
        {
            resource.SaveResource(folder);
        }
    }
    
}
