using CryptoMonitoringBybit.Models;
using System.Net.Http.Json;

namespace CryptoMonitoringBybit
{
	public class CryptoMonitoringBybitClient
	{
		private readonly HttpClient _client;

		public CryptoMonitoringBybitClient(HttpClient client) => _client = client;

		public async Task<Orderbook> GetOrderbook(string symbol = "BTCUSDT",
			IProgress<double> progress = null,
			CancellationToken cancellationToken = default)
		{
			var result = await _client.GetFromJsonAsync<Orderbook>($"/v5/market/orderbook?category=spot&symbol={symbol}",
				cancellationToken)
				.ConfigureAwait(false);

			return result;
		}

		public async Task<Ticker> GetTickers(ProductType productType,
			IProgress<double> progress = null,
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
			IProgress<double> progress = null,
			CancellationToken cancellationToken = default)
		{
			var categoryStr = productType.ToString().ToLower();

			var result = await _client.GetFromJsonAsync<Ticker>($"/v5/market/tickers?category={categoryStr}&symbol={symbolName}",
				cancellationToken)
				.ConfigureAwait(false);

			return result;
		}

		public async Task<SymbolInfo> GetSymbolInfo(ProductType productType,
			string symbolName = "BTCUSDT",
			IProgress<double> progress = null,
			CancellationToken cancellationToken = default)
		{
			var categoryStr = productType.ToString().ToLower();

			var result = await _client.GetFromJsonAsync<SymbolInfo>($"/v5/market/instruments-info?category={categoryStr}&symbol={symbolName}",
					cancellationToken)
					.ConfigureAwait(false);

			return result;
		}

		public async Task<MarkPriceInfo> GetMarketPriceInfo(ProductType productType = ProductType.SPOT,
			string symbolName = "BTCUSDT",
			string timeframe = "D",
			int limit = 1,
			IProgress<double> progress = null,
			CancellationToken cancellationToken = default)
		{
			var categoryStr = productType.ToString().ToLower();

			var result = await _client
				.GetFromJsonAsync<MarkPriceInfo>($"/v5/market/kline?category={categoryStr}&symbol={symbolName}&interval={timeframe}&limit={limit}",
				cancellationToken)
				.ConfigureAwait(false);

			return result;
		}
	}
}

