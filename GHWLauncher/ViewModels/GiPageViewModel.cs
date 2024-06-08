using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Avalonia.Media.Imaging;
using CommunityToolkit.Mvvm.ComponentModel;
using GHWLauncher.Helpers;
using GHWLauncher.Services;

namespace GHWLauncher.ViewModels;

public partial class GiPageViewModel : ViewModelBase
{
    private readonly LauncherContentService _launcherContentService;

    public GiPageViewModel(LauncherContentService lcs)
    {
        _launcherContentService = lcs;
        UpdateBgImage();
    }

    [ObservableProperty] private string _gib = "Posts Here";
    //public Bitmap? GiBackImage { get; } = ImageHelper.LoadFromResource(new Uri("avares://GHWLauncher/Assets/GiImage.jpg"));
    [ObservableProperty] private string? _giImageLink;

    void UpdateBgImage()
    {
        GiImageLink = _launcherContentService.GetBgImage(GameBiz.hk4e_cn);
    }
}