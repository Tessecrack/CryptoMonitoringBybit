using System.Net.Http.Json;
using CryptoMonitoringBybit.Models;

namespace CryptoMonitoringBybit
{
    public class CryptoMonitoringBybitClient
	{
		private readonly HttpClient _client;

		public CryptoMonitoringBybitClient(HttpClient client) => _client = client;

		public async Task<Orderbook> GetOrderbook(string symbol = "BTCUSDT", CancellationToken cancellationToken = default)
		{
			var result = await _client.GetFromJsonAsync<Orderbook>($"/v5/market/orderbook?category=spot&symbol={symbol}",
				cancellationToken)
				.ConfigureAwait(false);

			return result;
		}

		public async Task<Ticker> GetTickers(ProductType productType, 
			CancellationToken cancellationToken = default)
		{
			var categoryStr = productType.ToString().ToLower();

			var result = await _client.GetFromJsonAsync<Ticker>($"/v5/market/tickers?category={categoryStr}",
				cancellationToken)
				.ConfigureAwait(false);

			return result;
		}

		public async Task<Ticker> GetTickerBySymbol(ProductType productType, 
			string symbolName = "BTCUSDT", 
			CancellationToken cancellationToken = default)
		{
			var categoryStr = productType.ToString().ToLower();

			var result = await _client.GetFromJsonAsync<Ticker>($"/v5/market/tickers?category={categoryStr}&symbol={symbolName}",
				cancellationToken)
				.ConfigureAwait(false);

			return result;
		}
	}
}

