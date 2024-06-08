using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;
using GHWLauncher.Models;

namespace GHWLauncher.Services;

public class LauncherContentService
{
    private static HttpClient _httpClient = new();
    private static LauncherContent? _lContent;

    private async Task<T> CommonSendAsync<T>(HttpRequestMessage request) where T : class
    {
        request.Version = HttpVersion.Version20;
        var response = await _httpClient.SendAsync(request).ConfigureAwait(false);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync(typeof(miHoYoApiWrapper<T>), LauncherJsonContext.Default) as miHoYoApiWrapper<T>;
        if (responseData is null)
        {
            throw new miHoYoApiException(-1, "Can not parse the response body.");
        }
        if (responseData.Retcode != 0)
        {
            throw new miHoYoApiException(responseData.Retcode, responseData.Message);
        }
        return responseData.Data;
    }

    private LauncherContent GetGameRequestAsync(GameBiz biz)
    {
        /*
        var url = biz switch
        {
           GameBiz.hk4e_cn => "https://sdk-static.mihoyo.com/hk4e_cn/mdk/launcher/api/resource?channel_id=1&key=eYd89JmJ&launcher_id=18&sub_channel_id=1",
           GameBiz.hk4e_global => $"https://sdk-os-static.mihoyo.com/hk4e_global/mdk/launcher/api/resource?channel_id=1&key=gcStgarh&launcher_id=10&sub_channel_id=0",
           GameBiz.hk4e_bilibili => "https://hk4e-launcher-static.mihoyo.com/hk4e_cn/mdk/launcher/api/resource?channel_id=14&key=KAtdSsoQ&launcher_id=17&sub_channel_id=0",
           GameBiz.hkrpg_cn => "https://api-launcher-static.mihoyo.com/hkrpg_cn/mdk/launcher/api/resource?channel_id=1&key=6KcVuOkbcqjJomjZ&launcher_id=33&sub_channel_id=1",
           GameBiz.hkrpg_global => $"https://hkrpg-launcher-static.hoyoverse.com/hkrpg_global/mdk/launcher/api/resource?channel_id=1&key=vplOVX8Vn7cwG8yb&launcher_id=35&sub_channel_id=1",
           GameBiz.hkrpg_bilibili => "https://api-launcher-static.mihoyo.com/hkrpg_cn/mdk/launcher/api/resource?channel_id=14&key=fSPJNRwFHRipkprW&launcher_id=28&sub_channel_id=0",
           GameBiz.bh3_cn => $"https://bh3-launcher-static.mihoyo.com/bh3_cn/mdk/launcher/api/resource?channel_id=1&key=SyvuPnqL&launcher_id=4&sub_channel_id=1",
           GameBiz.bh3_overseas => $"https://sdk-os-static.mihoyo.com/bh3_global/mdk/launcher/api/resource?channel_id=1&key=tEGNtVhN&launcher_id=9&sub_channel_id=1",
           GameBiz.bh3_global => $"https://sdk-os-static.mihoyo.com/bh3_global/mdk/launcher/api/resource?key=dpz65xJ3&channel_id=1&launcher_id=10&sub_channel_id=1",
           GameBiz.bh3_tw => $"https://sdk-os-static.mihoyo.com/bh3_global/mdk/launcher/api/resource?channel_id=1&key=demhUTcW&launcher_id=8&sub_channel_id=1",
           GameBiz.bh3_kr => $"https://sdk-os-static.mihoyo.com/bh3_global/mdk/launcher/api/resource?channel_id=1&key=PRg571Xh&launcher_id=11&sub_channel_id=1",
           GameBiz.bh3_jp => $"https://sdk-os-static.mihoyo.com/bh3_global/mdk/launcher/api/resource?channel_id=1&key=ojevZ0EyIyZNCy4n&launcher_id=19&sub_channel_id=6",
           GameBiz.nap_cn => "https://nap-launcher-static.mihoyo.com/nap_cn/mdk/launcher/api/resource?channel_id=1&key=9HEb62Pw0qKYX4Mw&launcher_id=15&sub_channel_id=1",
           //GameBiz.nap_global => "",
           _ => throw new ArgumentOutOfRangeException($"Unknown region {biz}"),
        };
         */
        var url = "https://sdk-static.mihoyo.com/hk4e_cn/mdk/launcher/api/content?filter_adv=false&key=eYd89JmJ&language=zh-cn&launcher_id=18";
        var request = new HttpRequestMessage(HttpMethod.Get, url);
        _lContent = CommonSendAsync<LauncherContent>(request).Result;
        return _lContent;
    }

    public string GetBgImage(GameBiz g)
    {
        LauncherContent gameContent;
        if (_lContent == null)
        {
            gameContent = GetGameRequestAsync(g);
        } else {
            gameContent = _lContent;
        }

        return gameContent.BackgroundImage.Background;
    }
}