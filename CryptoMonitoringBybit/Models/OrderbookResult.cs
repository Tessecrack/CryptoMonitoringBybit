using System.Text.Json.Serialization;

namespace CryptoMonitoringBybit.Models
{
    [Serializable]
    public class OrderbookResult
    {
        [JsonPropertyName("b")]
        [JsonConverter(typeof(JsonPriceSizeConverter))]
        public List<PriceInfo> BidBuyers { get; set; }

        [JsonPropertyName("a")]
        [JsonConverter(typeof(JsonPriceSizeConverter))]
        public List<PriceInfo> AskBuyers { get; set; }

        [JsonPropertyName("s")]
        public string SymbolName { get; set; }

        [JsonPropertyName("ts")]
        public long Timestamp { get; set; }

        [JsonPropertyName("u")]
        public int UpdateId { get; set; }

        [JsonPropertyName("seq")]
        public long CrossSequence { get; set; }

		public override string ToString()
		{
            var resultStr = $"symbol: {SymbolName};";
            if (AskBuyers is not null && AskBuyers.Count > 0)
            {
                resultStr += $" ask: {string.Join(';', AskBuyers)}";
            }
            if (BidBuyers is not null && BidBuyers.Count > 0)
            {
                resultStr += $" bid: {string.Join(';', BidBuyers)}";
            }
            return resultStr;
		}
	}
}

