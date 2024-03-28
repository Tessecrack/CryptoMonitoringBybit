using System.Text.Json.Serialization;

namespace CryptoMonitoringBybit.Models
{
    [Serializable]
    public class Orderbook : BaseResponse
    {
        [JsonPropertyName("result")]
        public OrderbookResult Result { get; set; }
		public override string ToString()
		{
            var resultStr = base.ToString();
            if (Result is not null) 
            {
                resultStr += $" result: {Result}";
            }
			return resultStr;
		}
	}
}

