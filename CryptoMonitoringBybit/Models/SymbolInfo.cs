using System.Text.Json.Serialization;

namespace CryptoMonitoringBybit.Models
{
	public class SymbolInfo : BaseResponse
	{
		[JsonPropertyName("result")]
		public SymbolsInfo SymbolsInfo { get; set; }

		[JsonPropertyName("time")]
		public long Time { get; set; }
	}

	public class SymbolsInfo
	{
		[JsonPropertyName("category")]
		[JsonConverter(typeof(JsonStringEnumConverter))]
		public ProductType Category { get; set; }

		[JsonPropertyName("list")]
		public SymInfo[] ListSymInfo { get; set; }

		[JsonPropertyName("nextPageCursor")]
		public string PageCursor { get; set; }
	}

	public class SymInfo
	{
		[JsonPropertyName("symbol")]
		public string SymbolName { get; set; }

		[JsonPropertyName("contractType")]
		public string ContractType { get; set; }

		[JsonPropertyName("status")]
		public string Status { get; set; }

		[JsonPropertyName("baseCoin")]
		public string BaseCoin { get; set; }

		[JsonPropertyName("quoteCoin")]
		public string QuoteCoin { get; set; }

		[JsonPropertyName("launchTime")]
		public string LaunchTime { get; set; }

		[JsonPropertyName("deliveryTime")]
		public string DeliveryTime { get; set; }

		[JsonPropertyName("deliveryFeeRate")]
		public string DeliveryFeeRate { get; set; }

		[JsonPropertyName("priceScale")]
		public string PriceScale { get; set; }

		[JsonPropertyName("leverageFilter")]
		public Leveragefilter LeverageFilter { get; set; }

		[JsonPropertyName("priceFilter")]
		public Pricefilter PriceFilter { get; set; }

		[JsonPropertyName("lotSizeFilter")]
		public Lotsizefilter LotSizeFilter { get; set; }

		[JsonPropertyName("unifiedMarginTrade")]
		public bool UnifiedMarginTrade { get; set; }

		[JsonPropertyName("fundingInterval")]
		public int FundingInterval { get; set; }

		[JsonPropertyName("settleCoin")]
		public string SettleCoin { get; set; }

		[JsonPropertyName("copyTrading")]
		public string CopyTrading { get; set; }

		[JsonPropertyName("upperFundingRate")]
		public string UpperFundingRate { get; set; }

		[JsonPropertyName("lowerFundingRate")]
		public string LowerFundingRate { get; set; }
	}

	public class Leveragefilter
	{
		[JsonPropertyName("minLeverage")]
		public string MinLeverage { get; set; }
		[JsonPropertyName("maxLeverage")]
		public string MaxLeverage { get; set; }
		[JsonPropertyName("leverageStep")]
		public string LeverageStep { get; set; }
	}

	public class Pricefilter
	{
		[JsonPropertyName("minPrice")]
		public string MinPrice { get; set; }
		[JsonPropertyName("maxPrice")]
		public string MaxPrice { get; set; }
		[JsonPropertyName("tickSize")]
		public string TickSize { get; set; }
	}

	public class Lotsizefilter
	{
		[JsonPropertyName("maxOrderQty")]
		public string MaxOrderQty { get; set; }
		[JsonPropertyName("maxMktOrderQty")]
		public string MaxMktOrderQty { get; set; }
		[JsonPropertyName("minOrderQty")]
		public string MinOrderQty { get; set; }
		[JsonPropertyName("qtyStep")]
		public string QtyStep { get; set; }
		[JsonPropertyName("postOnlyMaxOrderQty")]
		public string PostOnlyMaxOrderQty { get; set; }
	}
}
