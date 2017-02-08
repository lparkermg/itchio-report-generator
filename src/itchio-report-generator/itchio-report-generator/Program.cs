using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;
using Entities;
using itchio_report_generator.ReportingObjects;
using Newtonsoft.Json;


namespace itchio_report_generator
{
    internal class Program
    {
        private const string API_BASE = "https://itch.io/api/1/";
        private const string API_KEY = "APIKEYLALALALALALALLA";

        public static void Main(string[] args)
        {
            //Get Game Details.
            var games = GetGamesList(API_KEY);
            //Extract relavent data.
            var reportObject = GenerateReportItems(games,false);
            //Produce pdf report.
            //Console.ReadLine();
        }

        private static Games GetGamesList(string key)
        {
            var client = new HttpClient();

            var res = client.GetStringAsync(new Uri($"{API_BASE}{key}/my-games")).Result;
            var games = JsonConvert.DeserializeObject<Games>(res);

            return games;
        }

        private static List<GameReportItem> GenerateReportItems(Games games, bool includeUnpublished)
        {
            var reportItems = new List<GameReportItem>();

            foreach (var game in games.games)
            {
                if (game.Published && !includeUnpublished)
                {
                    var earnings = game.Earnings ?? new List<Earning>()
                    {
                        new Earning()
                        {
                            Amount = 0.00,
                            AmountFormatted = "$0.00",
                            Currency = "USD"
                        }
                    };

                    reportItems.Add(new GameReportItem(game.Title, game.ShortText, game.CoverUrl, game.DownloadCount,
                        game.CreatedAt, game.PublishedAt, game.PurchaseAmount, earnings[0].AmountFormatted,
                        game.ViewsCount));
                }
            }

            return reportItems;
        }
    }
}