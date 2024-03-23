using System.Net.Http.Json;
using CryptoMonitoringBybit.Models;

namespace CryptoMonitoringBybit
{
    public class CryptoMonitoringBybitClient
	{
		private readonly HttpClient _client;

		public CryptoMonitoringBybitClient(HttpClient client) => _client = client;

		//private static readonly JsonSerializerOptions __JsonOptions = new()
		//{
		//	Converters =
		//	{
		//		new JsonPriceSizeConverter()
		//	}
		//};

		public async Task<Orderbook> GetOrderbook(string symbol = "BTCUSDT", CancellationToken cancellationToken = default)
		{
			return await _client.GetFromJsonAsync<Orderbook>($"/v5/market/orderbook?category=spot&symbol={symbol}",
				/*__JsonOptions,*/ cancellationToken).ConfigureAwait(false);
		}
	}
}

