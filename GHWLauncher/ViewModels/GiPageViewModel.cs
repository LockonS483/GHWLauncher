using System;
using System.Threading.Tasks;
using Avalonia.Media.Imaging;
using CommunityToolkit.Mvvm.ComponentModel;
using GHWLauncher.Helpers;

namespace GHWLauncher.ViewModels;

public partial class GiPageViewModel : ViewModelBase
{
    //public Bitmap? GiBackImage { get; } = ImageHelper.LoadFromResource(new Uri("avares://GHWLauncher/Assets/GiImage.jpg"));
    [ObservableProperty]
    private string _giImageLink = "https://launcher-webstatic.mihoyo.com/launcher-public/2024/04/23/209ab910dba69ea54d89a31e10bf82d6_4983283784718022512.png";
}