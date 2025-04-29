namespace Core.Interfaces.DataModels
{
    public interface ITrade
    {
        int TradeId { get; }
        ISecurity Security { get; }
        IFund Fund { get; }
        DateOnly TradeDate { get; }
        double Quantity { get; }
        double Price { get; }
        double Commission { get; }
    }
}
