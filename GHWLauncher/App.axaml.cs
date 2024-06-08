using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Data.Core.Plugins;
using Avalonia.Markup.Xaml;
using GHWLauncher.ViewModels;
using GHWLauncher.Views;
using Microsoft.Extensions.DependencyInjection;

namespace GHWLauncher;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        // Without this line you will get duplicate validations from both Avalonia and Community toolkit
        BindingPlugins.DataValidators.RemoveAt(0);
        
        // Register all the services needed for the application to run
        var collection = new ServiceCollection();
        collection.AddCommonServices();
        
        // Creates a ServiceProvider containing services from the provided IServiceCollection
        var services = collection.BuildServiceProvider();
        
        var vm = services.GetRequiredService<MainWindowViewModel>();
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = new MainWindow
            {
                DataContext = vm,
            };
        } else if (ApplicationLifetime is ISingleViewApplicationLifetime singleViewPlatform)
        {
            singleViewPlatform.MainView = new MainWindow()
            {
                DataContext = vm
            };
        }
        
        base.OnFrameworkInitializationCompleted();
    }
}