using DataModels.EntityFramework.PositionInformation.Contexts;
using DataModels.PositionData;
using Microsoft.EntityFrameworkCore;
using Services.Position;

namespace Services.IntegrationTests;

public class TradeServiceTests
{
    [Fact]
    public async Task GetTradesAsync_ReturnsTrades()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<PositionDataContext>()
            .UseInMemoryDatabase(databaseName: "TestDatabase")
            .Options;

        using var context = new PositionDataContext(options);
        context.Trades.AddRange(new List<Trade>
            {
                new Trade { TradeId = 1, FundId = 1, SecurityId = 1, TradeDate = DateTime.Now, Quantity = 100, Price = 10, CreateDateTime = DateTime.Now },
                new Trade { TradeId = 2, FundId = 1, SecurityId = 2, TradeDate = DateTime.Now, Quantity = 200, Price = 20, CreateDateTime = DateTime.Now }
            });
        await context.SaveChangesAsync();

        var tradeService = new TradeService(context);

        // Act
        var trades = await tradeService.GetTradesAsync();

        // Assert
        Assert.Equal(2, trades.Count());
    }
}
