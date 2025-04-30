namespace Core.Interfaces.DataModels
{
    public interface ITradeData
    {
        int TradeId { get; }
        int SecurityId { get; } // TODO: bigint?
        int FundId { get; }
        IFund Fund { get; }
        DateOnly TradeDate { get; }
        double Quantity { get; }
        double Price { get; }
        double Commission { get; }
    }
}
