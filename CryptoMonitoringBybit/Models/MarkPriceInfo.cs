using System.Text.Json.Serialization;

namespace CryptoMonitoringBybit.Models
{
	public class MarkPriceInfo : BaseResponse
	{
		[JsonPropertyName("result")]
		public MarkPriceSymInfo MarkPrice { get; set; }

		[JsonPropertyName("time")]
		public long Time { get; set; }


		public class MarkPriceSymInfo
		{
			[JsonPropertyName("symbol")]
			public string SymbolName { get; set; }

			[JsonPropertyName("category")]
			[JsonConverter(typeof(JsonStringEnumConverter))]
			public ProductType Category { get; set; }

			[JsonPropertyName("list")]
			public string[][] PriceList { get; set; } // ohlc
		}
	}
}
