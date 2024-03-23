using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;
using CryptoMonitoringBybit.Models;

namespace CryptoMonitoringBybit
{
    internal class JsonPriceSizeConverter : JsonConverter<List<PriceInfo>>
	{
		public override List<PriceInfo> Read(ref Utf8JsonReader reader, Type typeToConvert,
			JsonSerializerOptions options)
		{
			if (reader.TokenType != JsonTokenType.StartArray)
			{
				throw new JsonException("Wrong PriceInfo bid or ask");
			}
			List<PriceInfo> listPriceInfo = new List<PriceInfo>();
			bool isEndArray = false;
			while (true)
			{
				if (!reader.Read())
				{
					break;
				}
				PriceInfo priceInfo = new PriceInfo();
				if (reader.TokenType == JsonTokenType.StartArray)
				{
					reader.Read();

					if (!double.TryParse(JsonSerializer.Deserialize<string>(ref reader, options), CultureInfo.InvariantCulture,
						out double price))
					{
						break;
					}
					priceInfo.Price = price;
					reader.Read();
					if (!double.TryParse(JsonSerializer.Deserialize<string>(ref reader, options), CultureInfo.InvariantCulture,
						out double size))
					{
						break;
					};
					priceInfo.Size = size;
					reader.Read();
					isEndArray = false;
				}
				if (reader.TokenType == JsonTokenType.EndArray)
				{
					if (isEndArray) { break; }
					listPriceInfo.Add(priceInfo);
					isEndArray = true;
				}
			}

			return listPriceInfo;
		}

		public override void Write(Utf8JsonWriter writer, List<PriceInfo> value,
			JsonSerializerOptions options)
		{

			writer.WriteStringValue($"{value.Count} {value.Count}");
		}
	}
}

