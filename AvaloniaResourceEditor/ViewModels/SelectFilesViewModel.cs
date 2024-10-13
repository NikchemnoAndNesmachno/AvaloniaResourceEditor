using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Threading.Tasks;
using AvaloniaResourceEditor.Services;
using CommunityToolkit.Mvvm.ComponentModel;

namespace AvaloniaResourceEditor.ViewModels;

public partial class SelectFilesViewModel : ViewModelBase
{
    [ObservableProperty] private string _folder = "";
    public ObservableCollection<string> AllFiles { get; set; } = [];
    public ObservableCollection<string> SelectedFiles { get; set; } = [];

    public Action OnConfirm { get; set; } = () => { };

    public void Confirm()
    {
        OnConfirm();
    }
    
    public void Read()
    {
        AllFiles.Clear();
        var folder = new DirectoryInfo(Folder);
        var files = folder.GetFiles("*.axaml", SearchOption.TopDirectoryOnly);
        foreach (var file in files)
        {
            AllFiles.Add(file.FullName);
        }
    }
    
    public async Task BrowseFolder()
    {
        var service = ServiceManager.Get<IFileService>();
        Folder = await service.GetFolder();
        Read();
    }
}