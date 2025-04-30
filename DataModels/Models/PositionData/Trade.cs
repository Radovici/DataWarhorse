using Core.Interfaces.DataModels;

namespace DataModels.PositionData;

public partial class Trade : ITradeData
{
    public int TradeId { get; set; }

    public int FundId { get; set; }

    public int SecurityId { get; set; }

    public DateOnly TradeDate { get; set; }

    public double Quantity { get; set; }

    public double Price { get; set; }

    public DateTime CreateDateTime { get; set; }

    public virtual Fund Fund { get; set; } = null!;

    IFund ITradeData.Fund => this.Fund;

    // NOTE: Trade should have commission and currency (trade currency, not always the security's currency, i.e., multi-currency swaps)
    public double Commission { get; set; }

    public int CurrencyId { get; set; }
}
