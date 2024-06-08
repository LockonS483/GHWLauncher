using GHWLauncher.ViewModels;
using GHWLauncher.Services;
using Microsoft.Extensions.DependencyInjection;

namespace GHWLauncher;

public static class ServiceCollectionExtensions {
    public static void AddCommonServices(this IServiceCollection collection) {
        collection.AddSingleton<LauncherContentService>();
        collection.AddTransient<MainWindowViewModel>();
        collection.AddTransient<GiPageViewModel>();
    }
}