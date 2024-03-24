namespace CryptoMonitoringBybit.Models
{
    [Serializable]
    public class PriceInfo
    {
        public double Price { get; set; }

        public double Size { get; set; }

		public override string ToString()
		{
			return $"Price: {Price}; Size: {Size}";
		}
	}
}

