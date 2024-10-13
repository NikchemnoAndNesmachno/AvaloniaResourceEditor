using Avalonia.Controls;
using Avalonia.Interactivity;
using AvaloniaResourceEditor.Services;
using AvaloniaResourceEditor.ViewModels;

namespace AvaloniaResourceEditor.Views;

public partial class MainWindow : Window
{
    public MainWindow(MainWindowViewModel vm)
    {
        InitializeComponent();
        DataContext = vm;
    }

    private void OpenBrowse(object? sender, RoutedEventArgs e)
    {
        var window = ServiceManager.Get<SelectFilesWindow>();
        window.ShowDialog(this);
    }
}