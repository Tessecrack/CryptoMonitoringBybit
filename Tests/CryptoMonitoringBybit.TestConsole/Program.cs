using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

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
		
	}

	 static async Task Main(string[] args)
	{
		using var host = Hosting;

		await host.StartAsync();

		Console.WriteLine("Done!");
		Console.ReadKey();

		await host.StopAsync();
	}
}