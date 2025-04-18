using Core.Interfaces.Services;
using DataModels.EntityFramework.MarketData.Contexts;
using DataModels.EntityFramework.PositionInformation.Contexts;
using DataModels.EntityFramework.SecurityMaster.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Services.MarketData;
using Services.Position;
using Services.Security;

namespace Services.IntegrationTests;

public class TradeServiceTests
{
    private readonly IHost _host;

    public TradeServiceTests()
    {
        _host = CreateHostBuilder().Build();
    }

    private static IHostBuilder CreateHostBuilder() =>
        Host.CreateDefaultBuilder()
            .ConfigureAppConfiguration((context, config) =>
            {
                config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            })
            .ConfigureServices((context, services) =>
            {
                // Register EF Core DbContexts
                services.AddDbContext<SecurityMasterContext>(options =>
                    options.UseSqlServer(context.Configuration.GetConnectionString("SecurityMasterDatabase")));
                services.AddDbContext<MarketDataContext>(options =>
                    options.UseSqlServer(context.Configuration.GetConnectionString("MarketDataDatabase")));
                services.AddDbContext<PositionDataContext>(options =>
                    options.UseSqlServer(context.Configuration.GetConnectionString("PositionDataDatabase")));

                // Services
                services.AddScoped<ISecurityService, SecurityService>();
                services.AddScoped<ITradeService, TradeService>();
                services.AddScoped<IMarketDataService, MarketDataService>();
            });

    [Fact]
    public async Task GetTradesAsync_ReturnsTrades()
    {
        using var scope = _host.Services.CreateScope();
        var tradeService = scope.ServiceProvider.GetRequiredService<ITradeService>();

        // Act
        var trades = await tradeService.GetTradesAsync();

        // Assert
        Assert.NotNull(trades);
        Assert.True(trades.Any(), "No trades were returned.");
        Console.WriteLine($"Number of trades: {trades.Count()}");
    }

    [Fact]
    public async Task GetSPXSecurityPrices_ReturnsPrices()
    {
        using var scope = _host.Services.CreateScope();
        var securityMasterContext = scope.ServiceProvider.GetRequiredService<SecurityMasterContext>();
        var marketDataContext = scope.ServiceProvider.GetRequiredService<MarketDataContext>();

        // Arrange
        var spxSecurities = await securityMasterContext.Securities
            .Where(s => s.Symbol == "SPX" && s.Exchange.Name.ToLower() == "index")
            .ToListAsync();

        int[] spxSecurityIds = spxSecurities.Select(s => s.Id).ToArray();

        // Act
        var spxSecurityPrices = await marketDataContext.EquityPrices
            .Where(p => spxSecurityIds.Contains(p.SecurityId))
            .ToListAsync();

        // Assert
        Assert.NotNull(spxSecurityPrices);
        Assert.True(spxSecurityPrices.Any(), "No SPX security prices were returned.");
        Console.WriteLine($"SPX Security Prices Count: {spxSecurityPrices.Count}");
    }
}
