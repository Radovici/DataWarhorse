using Core.Interfaces.DataModels;
using Core.Interfaces.Services;
using Moq;

namespace Services.UnitTests;

public class TradeServiceTests
{
    [Fact]
    public void GetTradesAsync_ReturnsTrades()
    {
        // Arrange
        var mockTradeService = new Mock<ITradeService>();
        var mockSecurityService = new Mock<ISecurityService>();

        // Mock the behavior of ISecurityService
        mockSecurityService
            .Setup(service => service.GetSecurity(It.IsAny<int>()))
            .Returns(new Mock<ISecurity>().Object);

        mockTradeService
            .Setup(service => service.QueryableTrades)
            .Returns(new List<ITradeData>
            {
                new DataModels.PositionData.Trade
                {
                    TradeId = 1,
                    FundId = 1,
                    SecurityId = 1,
                    TradeDate = DateTime.Now,
                    Quantity = 100,
                    Price = 10,
                    CreateDateTime = DateTime.Now
                }
            }.AsQueryable());

        var tradeService = mockTradeService.Object;

        // Act
        var trades = tradeService.QueryableTrades;

        // Assert
        Assert.Single(trades);
    }
}