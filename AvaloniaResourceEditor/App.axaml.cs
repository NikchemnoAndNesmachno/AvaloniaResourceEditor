using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Data.Core;
using Avalonia.Data.Core.Plugins;
using Avalonia.Markup.Xaml;
using AvaloniaResourceEditor.Services;
using AvaloniaResourceEditor.ViewModels;
using AvaloniaResourceEditor.Views;
using AvaloniaResourceEditor.Views.ServiceImplementation;
using Microsoft.Extensions.DependencyInjection;

namespace AvaloniaResourceEditor;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            // Line below is needed to remove Avalonia data validation.
            // Without this line you will get duplicate validations from both Avalonia and CT
            BindingPlugins.DataValidators.RemoveAt(0);
            ServiceManager.Services.AddSingleton<SelectFilesViewModel>();
            ServiceManager.Services.AddSingleton<MainViewModel>();
            ServiceManager.Services.AddSingleton<ShellViewModel>();
            ServiceManager.Services.AddSingleton<MainWindow>();
            ServiceManager.Services.AddSingleton<IFileService, FileService>();
            
            ServiceManager.Init();
            
            desktop.MainWindow = ServiceManager.Get<MainWindow>();
        }

        base.OnFrameworkInitializationCompleted();
    }
}