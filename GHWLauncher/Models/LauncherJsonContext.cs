using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using GHWLauncher.Models;

namespace GHWLauncher;

[JsonSerializable(typeof(miHoYoApiWrapper<LauncherContent>))]
[JsonSerializable(typeof(miHoYoApiWrapper<LauncherGameResource>))]
[JsonSerializable(typeof(miHoYoApiWrapper<CloudGameBackgroundWrapper>))]
[JsonSerializable(typeof(miHoYoApiWrapper<AlertAnn>))]
[JsonSerializable(typeof(miHoYoApiWrapper<JsonNode>))]
internal partial class LauncherJsonContext : JsonSerializerContext
{

}