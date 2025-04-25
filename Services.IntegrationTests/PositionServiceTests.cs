using Core.Interfaces.Services;
using DataModels.EntityFramework.MarketData.Contexts;
using DataModels.EntityFramework.PositionInformation.Contexts;
using DataModels.EntityFramework.SecurityMaster.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PositionFramework;
using Services.MarketData;
using Services.Position;
using Services.Security;
using Xunit.Abstractions;

namespace Services.IntegrationTests;

public class PositionServiceTests
{
    private readonly IHost _host;
    private readonly ITestOutputHelper _output;

    public PositionServiceTests(ITestOutputHelper output)
    {
        _output = output;
        _host = CreateHostBuilder().Build();
    }

    private static IHostBuilder CreateHostBuilder() =>
        Host.CreateDefaultBuilder()
            .ConfigureAppConfiguration((context, config) =>
            {
                config.AddJsonFile("appsettings.development.json", optional: false, reloadOnChange: true);
            })
            .ConfigureServices((context, services) =>
            {
                // Register EF Core DbContexts
                string connectionString = context.Configuration.GetConnectionString("DataWarhorse")!;
                services.AddDbContext<SecurityMasterContext>(options => options.UseSqlServer(connectionString));
                services.AddDbContext<MarketDataContext>(options => options.UseSqlServer(connectionString));
                services.AddDbContext<PositionDataContext>(options => options.UseSqlServer(connectionString));

                // Services
                services.AddScoped<ISecurityService, SecurityService>();
                services.AddScoped<ITradeService, TradeService>();
                services.AddScoped<IMarketDataService, MarketDataService>();
                services.AddScoped<IPositionService, PositionService>();
            });

    [Fact]
    public void TestIQueryableTradeServiceTest()
    {
        using var scope = _host.Services.CreateScope();
        var tradeService = scope.ServiceProvider.GetRequiredService<ITradeService>();

        // Act
        var trades = tradeService.QueryableTrades.Take(1);

        // Assert
        Assert.NotNull(trades);
        Assert.True(trades.Count() == 1, "Take(1) didn't work.");
        _output.WriteLine($"Number of trades: {trades.Count()}");
    }

    [Fact]
    public void PortfolioPnlTest()
    {
        using var scope = _host.Services.CreateScope();
        var tradeService = scope.ServiceProvider.GetRequiredService<ITradeService>();

        // Act
        var queryableTrades = tradeService.QueryableTrades.Take(10);
        var trades = tradeService.GetUnifiedTrades(queryableTrades);
        _output.WriteLine($"Number of trades = {trades.Count()}.");
        Portfolio portfolio = new Portfolio(trades);

        // Assert
        Assert.True(portfolio.Pnl != 0, "There should be pnl.");
        _output.WriteLine($"Portfolio pnl: {portfolio.Pnl}");
    }
}
