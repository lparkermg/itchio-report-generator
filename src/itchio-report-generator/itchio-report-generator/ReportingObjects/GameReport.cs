using System;

namespace itchio_report_generator.ReportingObjects
{
    public class GameReportItem
    {
        public string Title { get; private set; }
        public string Description { get; private set; }
        public string CoverUrl { get; private set; }
        public int DownloadsCount { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime PublishedAt { get; private set; }
        public int PurchasesAmount { get; private set; }
        public string TotalEarnt { get; private set; }
        public int TotalViews { get; private set; }

        public GameReportItem(string title, string description, string coverUrl, int downloadsCount, DateTime createdAt, DateTime publishedAt, int purchasesAmount, string totalEarnt, int totalViews)
        {
            Title = title;
            Description = description;
            CoverUrl = coverUrl;
            DownloadsCount = downloadsCount;
            CreatedAt = createdAt;
            PublishedAt = publishedAt;
            PurchasesAmount = purchasesAmount;
            TotalEarnt = totalEarnt;
            TotalViews = totalViews;
        }

        public string GenerateTableRow()
        {
            return $"<tr><td>\"{Title}\"<br><img src=\"{CoverUrl}\"></img></td><td>{Description}</td><td>{CreatedAt}</td><td>{PublishedAt}</td><td>{TotalViews}</td><td>{DownloadsCount}</td><td>{PurchasesAmount}</td><td>{TotalEarnt}</td></tr>";
        }
    }
}