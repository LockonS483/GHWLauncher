using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GHWLauncher.Services;

namespace GHWLauncher.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    private readonly LauncherContentService _launcherContentService;
    [ObservableProperty] private ViewModelBase _giPageViewModel;
    
    public MainWindowViewModel(LauncherContentService lcs)
    {
        _launcherContentService = lcs;
        GiPageViewModel = new GiPageViewModel(_launcherContentService);
    }
}