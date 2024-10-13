using CommunityToolkit.Mvvm.ComponentModel;

namespace AvaloniaResourceEditor.ViewModels;

public partial class ResourceFile: ViewModelBase
{
    [ObservableProperty] private string _name = "new";
}