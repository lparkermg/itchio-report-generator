using System.Collections.Generic;
using Newtonsoft.Json;

namespace Entities
{
    public class Games
    {
        [JsonProperty("games")] public readonly List<Game> games;
    }
}