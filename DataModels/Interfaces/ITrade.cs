namespace DataModels.Interfaces
{
    public interface ITrade
    {
        int TradeId { get; }
        ISecurity Security { get; }
        IFund Fund { get; }
        DateTime TradeDate { get; }
        double Quantity { get; }
        double Price { get; }
        double MarketValue { get; }
        double DeltaExposure { get; }
        double Cost { get; }
        double Commission { get; }
        double GetOpenDeltaExposure(bool isLong); // NOTE: this doesn't belong here.
    }
}
