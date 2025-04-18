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
        double Commission { get; }
    }
}
