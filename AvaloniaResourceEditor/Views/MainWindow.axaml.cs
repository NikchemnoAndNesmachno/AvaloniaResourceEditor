using Avalonia.Controls;
using Avalonia.Interactivity;
using AvaloniaResourceEditor.Services;
using AvaloniaResourceEditor.ViewModels;

namespace AvaloniaResourceEditor.Views;

public partial class MainWindow : Window
{
    public MainWindow(ShellViewModel vm)
    {
        InitializeComponent();
        DataContext = vm;
    }
}