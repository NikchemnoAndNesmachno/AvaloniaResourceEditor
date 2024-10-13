using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using AvaloniaResourceEditor.Services;
using AvaloniaResourceEditor.ViewModels;

namespace AvaloniaResourceEditor.Views;

public partial class SelectFilesWindow : Window
{
    public SelectFilesWindow(SelectFilesViewModel vm)
    {
        InitializeComponent();
        DataContext = vm;
    }

    private void OnCancel(object? sender, RoutedEventArgs e)
    {
        Close();
    }
}