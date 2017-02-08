using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Entities
{
    public class Game
    {
        [JsonProperty("id")] public readonly int Id;
        [JsonProperty("cover_url")] public readonly string CoverUrl;
        [JsonProperty("created_at")] public readonly DateTime CreatedAt;
        [JsonProperty("downloads_count")] public readonly int DownloadCount;
        [JsonProperty("min_price")] public readonly double MinPrice;
        [JsonProperty("p_android")] public readonly bool OnAndroid;
        [JsonProperty("p_linux")] public readonly bool OnLinux;
        [JsonProperty("p_osx")] public readonly bool OnMacOs;
        [JsonProperty("pp_windows")] public readonly bool OnWindows;
        [JsonProperty("published")] public readonly bool Published;
        [JsonProperty("published_at")] public readonly DateTime PublishedAt;
        [JsonProperty("purchases_count")] public readonly int PurchaseAmount;
        [JsonProperty("short_text")] public readonly string ShortText;
        [JsonProperty("title")] public readonly string Title;
        [JsonProperty("type")] public readonly string Type;
        [JsonProperty("url")] public readonly string Url;
        [JsonProperty("views_count")] public readonly int ViewsCount;
        [JsonProperty("earnings")] public readonly List<Earning> Earnings;
    }
}