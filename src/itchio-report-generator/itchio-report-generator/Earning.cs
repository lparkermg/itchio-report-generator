using Newtonsoft.Json;

namespace Entities
{
    public class Earning
    {
        [JsonProperty("currency")] public string Currency;
        [JsonProperty("amount_formatted")] public string AmountFormatted;
        [JsonProperty("amount")] public double Amount;

    }
}