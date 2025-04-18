using Core.Interfaces.Services;
using DataModels.EntityFramework.MarketData.Contexts;
using DataModels.EntityFramework.PositionInformation.Contexts;
using DataModels.EntityFramework.SecurityMaster.Contexts;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Services.Position;
using Services.Security;

namespace Tester;

class Program
{
    static async Task Main(string[] args)
    {
        var host = CreateHostBuilder(args).Build();

        using var scope = host.Services.CreateScope();
        var services = scope.ServiceProvider;

        try
        {
            var tradeTest = services.GetRequiredService<TradeTest>();
            var trades = await tradeTest.GetTradesAsync();

            var test = services.GetRequiredService<SecurityTest>(); // Resolve App from DI
            await test.RunAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureServices((context, services) =>
            {
                // Register EF Core DbContexts
                services.AddDbContext<SecurityMasterContext>();
                services.AddDbContext<MarketDataContext>();
                services.AddScoped<ISecurityService, SecurityService>();

                services.AddDbContext<PositionDataContext>();
                services.AddScoped<ITradeService, TradeService>();

                // Register Application Services
                services.AddTransient<SecurityTest>(); // Main application logic
                services.AddTransient<TradeTest>(); // Main application logic
            });
}