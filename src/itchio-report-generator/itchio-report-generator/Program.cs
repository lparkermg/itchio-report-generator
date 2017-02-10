using System;
using System.Collections.Generic;
using System.IO;
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
        private const string API_KEY = "APIKEYHERE";

        public static void Main(string[] args)
        {
            //Get Game Details.
            var games = GetGamesList(API_KEY);
            //Extract relavent data.
            var reportObject = GenerateReportItems(games,false);
            //Produce html report.
            var report = GenerateReportHeader();
            report += GenerateReportBodyTop();
            foreach (var reportItem in reportObject)
            {
                report += reportItem.GenerateTableRow();
            }

            report += GenerateeportFooter();

            File.WriteAllText($"./report-{DateTime.Now.ToString("dd-MM-yyyy-hhmmss")}.html",report);
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

        private static void GenerateHtml(string title, List<GameReportItem> reportItems)
        {

        }

        private static string GenerateReportHeader()
        {
            var html = "<!DOCTYPE html>\n";
            html += "<head>\n";
            html += "<title>Itch.io Report</title>\n";
            html += "<link rel=\"stylesheet\" type=\"text/css\" href=\"main.css\">\n";
            html += "</head>";

            return html;

        }

        private static string GenerateReportBodyTop()
        {
            var html = "<body>\n";
            html += "<header class=\"header-main\">\n";
            html += "</header>\n";
            html +=
                "<table><tr><th></th><th>Description</th><th>Creation Date</th><th>Published Date</th><th>Views/Downloads/Purchases</th><th>Earnings</th></tr>";
            return html;
        ;
    }

        private static string GenerateeportFooter()
        {
            return "</table></body></html>";
        }
    }
}