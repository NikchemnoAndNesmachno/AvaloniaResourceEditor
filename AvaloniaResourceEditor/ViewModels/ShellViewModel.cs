namespace AvaloniaResourceEditor.ViewModels;

public class ShellViewModel(MainViewModel main, SelectFilesViewModel select): ViewModelBase
{
    public MainViewModel MainViewModel { get; set; } = main;
    public SelectFilesViewModel SelectViewModel { get; set; } = select;
}