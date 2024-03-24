using System.Text.Json.Serialization;

namespace CryptoMonitoringBybit.Models
{
	[Serializable]
	public class Ticker
	{
		[JsonPropertyName("retCode")]
		public int RetCode { get; set; }

		[JsonPropertyName("retMsg")]
		public string RetMsg { get; set; }

		[JsonPropertyName("result")]
		public TickerInfo Result { get; set; }

		public override string ToString()
		{
			var resultStr = $"retCode: {RetCode}; retMsg: {RetMsg};";
			if (Result is not null)
			{
				resultStr += $" {Result};";
			}
			return resultStr;
		}
	}

	[Serializable]
	public class TickerInfo
	{
		[JsonPropertyName("category")]
		[JsonConverter(typeof(JsonStringEnumConverter))]
		public ProductType ProductType { get; set; }

		[JsonPropertyName("list")]
		public List<Info> TickersInfo { get; set; }

		public override string ToString()
		{
			var resultStr = $"category: {ProductType};";
			if (TickersInfo is not null && TickersInfo.Count > 0)
			{
				resultStr += $" {string.Join(';', TickersInfo)}";
			}
			return resultStr;
		}
	}

	[Serializable]
	public class Info
	{
		[JsonPropertyName("symbol")]
		public string Symbol { get; set; }

		[JsonPropertyName("lastPrice")]
		public double LastPrice { get; set; }

		[JsonPropertyName("indexPrice")]
		public double IndexPrice { get; set; }

		[JsonPropertyName("markPrice")]
		public double MarkPrice {  get; set; }

		[JsonPropertyName("highPrice24h")]
		public double HighPrice { get; set; }

		[JsonPropertyName("lowPrice24h")]
		public double LowPrice { get; set; }

		[JsonPropertyName("openInterest")]
		public double OpenInterest { get; set; }

		[JsonPropertyName("openInterestValue")]
		public double OpenInterestValue { get; set; }

		[JsonPropertyName("volume24h")]
		public double Volume { get; set; }

		[JsonPropertyName("fundingRate")]
		public double FundingRate { get; set; }

		public override string ToString()
		{
			return $"symbol: {Symbol}; last: {LastPrice} ; high: {HighPrice}; low: {LowPrice}";
		}
	}

	public enum ProductType : byte
	{
		SPOT,
		LINEAR,
		INVERSE, 
		OPTION
	}
}
