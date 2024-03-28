using System.Text.Json.Serialization;

namespace CryptoMonitoringBybit.Models
{
	public class BaseResponse
	{
		[JsonPropertyName("retCode")]
		public int RetCode { get; set; }

		[JsonPropertyName("retMsg")]
		public string RetMsg { get; set; }

		[JsonPropertyName("retExtInfo")]
		public object RetExtInfo { get; set; }


		public override string ToString()
		{
			return $"retCode: {RetCode}; retMsg: {RetMsg};";
		}
	}
}
