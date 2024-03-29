﻿using CryptoMonitoringBybit;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using CryptoMonitoringBybit.Models;
using Polly;
using Polly.Extensions.Http;

class Program
{
	private static IHost __Hosting;

	public static IHost Hosting => __Hosting ??= CreateHostBuilder(Environment.GetCommandLineArgs()).Build();

	public static IHostBuilder CreateHostBuilder(string[] args) =>
		Host.CreateDefaultBuilder(args)
		.ConfigureServices(ConfigureService);

	public static IServiceProvider Services => Hosting.Services;

	private static void ConfigureService(HostBuilderContext host, IServiceCollection services)
	{
		services.AddHttpClient<CryptoMonitoringBybitClient>(client
			=> client.BaseAddress = new Uri(host.Configuration["Bybit"]))
			.SetHandlerLifetime(TimeSpan.FromMinutes(5))
			.AddPolicyHandler(GetRetryPolicy());
	}

	private static IAsyncPolicy<HttpResponseMessage> GetRetryPolicy()
	{
		var jitter = new Random();

		return HttpPolicyExtensions
			.HandleTransientHttpError()
			.WaitAndRetryAsync(6, retry_attempt => TimeSpan.FromSeconds(Math.Pow(2, retry_attempt)) 
			+ TimeSpan.FromMilliseconds(jitter.Next(0, 1000)));
	}

	static async Task Main(string[] args)
	{
		using var host = Hosting;

		await host.StartAsync();

		var bybitClient = Services.GetService<CryptoMonitoringBybitClient>();

		var orderBook = await bybitClient.GetOrderbook();

		var ticker = await bybitClient.GetTickerBySymbol(ProductType.SPOT, "TONUSDT");

		var tickers = await bybitClient.GetTickers(ProductType.SPOT);

		var symbolInfo = await bybitClient.GetSymbolInfo(ProductType.SPOT, "TONUSDT");

		var markPriceInfo = await bybitClient.GetMarketPriceInfo(ProductType.SPOT, "TONUSDT");

		Console.WriteLine("\n------\n");

		Console.WriteLine("Done!");
		Console.ReadKey();

		await host.StopAsync();
	}
}