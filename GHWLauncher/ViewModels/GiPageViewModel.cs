using System;
using System.Threading.Tasks;
using Avalonia.Media.Imaging;
using CommunityToolkit.Mvvm.ComponentModel;
using GHWLauncher.Helpers;

namespace GHWLauncher.ViewModels;


public partial class GiPageViewModel : ViewModelBase
{
    //public Bitmap? GiBackImage { get; } = ImageHelper.LoadFromResource(new Uri("avares://GHWLaucher/Assets/abstract.jpg"));
    public Task<Bitmap?> GiBackImage { get; } = ImageHelper.LoadFromWeb(new Uri("https://upload.wikimedia.org/wikipedia/commons/4/41/NewtonsPrincipia.jpg"));
}