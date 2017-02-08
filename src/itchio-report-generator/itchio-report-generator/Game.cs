using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entities
{
    public class Game
    {
        public int Id { get; private set; }
        public string CoverUrl { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public int DownloadCount { get; private set; }
        public double MinPrice { get; private set; }
        public bool OnAndroid { get; private set; }
        public bool OnLinux { get; private set; }
        public bool OnMacOs { get; private set; }
        public bool OnWindows { get; private set; }
        public bool Published { get; private set; }
        public DateTime PublishedAt { get; private set; }
        public int PurchaseAmount { get; private set; }
        public string ShortText { get; private set; }
        public string Title { get; private set; }
        public string Type { get; private set; }
        public string Url { get; private set; }
        public int ViewsCount { get; private set; }
        public List<Earning> Earnings { get; private set; }


        public Game(int id, string coverUrl, DateTime createdAt, int downloadCount, double minPrice, bool onAndroid, bool onLinux, bool onMacOs, bool onWindows, bool published, DateTime publishedAt, int purchaseAmount, string shortText, string title, string type, string url, int viewsCount, List<Earning> earnings)
        {
            Id = id;
            CoverUrl = coverUrl;
            CreatedAt = createdAt;
            DownloadCount = downloadCount;
            MinPrice = minPrice;
            OnAndroid = onAndroid;
            OnLinux = onLinux;
            OnMacOs = onMacOs;
            OnWindows = onWindows;
            Published = published;
            PublishedAt = publishedAt;
            PurchaseAmount = purchaseAmount;
            ShortText = shortText;
            Title = title;
            Type = type;
            Url = url;
            ViewsCount = viewsCount;
            Earnings = earnings;
        }
    }
}