using Core.Interfaces.DataModels;
using Core.Interfaces.Services;
using Moq;

namespace Services.UnitTests;

public class TradeServiceTests
{
    [Fact]
    public async Task GetTradesAsync_ReturnsTrades()
    {
        // Arrange
        var mockTradeService = new Mock<ITradeService>();
        var mockSecurityService = new Mock<ISecurityService>();

        // Mock the behavior of ISecurityService
        mockSecurityService
            .Setup(service => service.GetSecurity(It.IsAny<int>()))
            .Returns(new Mock<ISecurity>().Object);

        var setup = mockTradeService.Setup(service => service.GetTradesAsync());
        setup.ReturnsAsync(new List<ITrade>
            {
                new UnifiedDataModels.Models.PositionData.Trade(
                    new DataModels.PositionData.Trade
                    {
                        TradeId = 1,
                        FundId = 1,
                        SecurityId = 1,
                        TradeDate = DateTime.Now,
                        Quantity = 100,
                        Price = 10,
                        CreateDateTime = DateTime.Now
                    },
                    mockSecurityService.Object) // Inject the mocked ISecurityService
            });

        var tradeService = mockTradeService.Object;

        // Act
        var trades = await tradeService.GetTradesAsync();

        // Assert
        Assert.Equal(2, trades.Count());
    }
}