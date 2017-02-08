using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Entities;


namespace itchio_report_generator
{
    internal class Program
    {
        private const string API_BASE = "https://itch.io/api/1/";

        public static void Main(string[] args)
        {
            //Get Game Details.
            var games = GetGamesList("M6k16zoC8Ls1ty2pEOxc4Ul1R3jTK85dl4buj630");
            //Extract relavent data.

            //Produce pdf report.
            Console.ReadLine();
        }

        private static List<Game> GetGamesList(string key)
        {
            var games = new List<Game>();

            using (var client = new HttpClient())
            {
                var res = client.GetStringAsync($"{API_BASE}{key}/my-games").Result;
                Console.Write(res);

            }

            return games;
        }
    }
}