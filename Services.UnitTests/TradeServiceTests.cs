using DataModels.PositionData;
using Moq;
using Services.Position;

namespace Services.UnitTests;

public class TradeServiceTests
{
    [Fact]
    public async Task GetTradesAsync_ReturnsTrades()
    {
        // Arrange
        var mockTradeService = new Mock<ITradeService>();
        var setup = mockTradeService.Setup(service => service.GetTradesAsync());
        setup.ReturnsAsync(new List<Trade>
            {
                    new Trade { TradeId = 1, FundId = 1, SecurityId = 1, TradeDate = DateTime.Now, Quantity = 100, Price = 10, CreateDateTime = DateTime.Now },
                    new Trade { TradeId = 2, FundId = 1, SecurityId = 2, TradeDate = DateTime.Now, Quantity = 200, Price = 20, CreateDateTime = DateTime.Now }
            });

        var tradeService = mockTradeService.Object;

        // Act
        var trades = await tradeService.GetTradesAsync();

        // Assert
        Assert.Equal(2, trades.Count());
    }
}
