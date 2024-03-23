using System.Text.Json.Serialization;

namespace CryptoMonitoringBybit.Models
{
    [Serializable]
    public class Orderbook
    {
        [JsonPropertyName("retCode")]
        public int RetCode { get; set; }

        [JsonPropertyName("retMsg")]
        public string RetMsg { get; set; }

        [JsonPropertyName("result")]
        public OrderbookResult Result { get; set; }

        [JsonPropertyName("retExtInfo")]
        public object RetExtInfo { get; set; }
    }
}

