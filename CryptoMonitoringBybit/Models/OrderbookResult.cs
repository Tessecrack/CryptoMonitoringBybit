using System.Text.Json.Serialization;

namespace CryptoMonitoringBybit.Models
{
    [Serializable]
    public class OrderbookResult
    {
        [JsonPropertyName("b")]
        [JsonConverter(typeof(JsonPriceSizeConverter))]
        public List<PriceInfo> BidBuyer { get; set; }

        [JsonPropertyName("a")]
        [JsonConverter(typeof(JsonPriceSizeConverter))]
        public List<PriceInfo> AskBuyer { get; set; }

        [JsonPropertyName("s")]
        public string SymbolName { get; set; }

        [JsonPropertyName("ts")]
        public long Timestamp { get; set; }

        [JsonPropertyName("u")]
        public int UpdateId { get; set; }

        [JsonPropertyName("seq")]
        public long CrossSequence { get; set; }
    }
}

