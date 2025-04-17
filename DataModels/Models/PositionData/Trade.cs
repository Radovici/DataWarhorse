using DataModels.Interfaces;

namespace DataModels.PositionData;

public partial class Trade : ITrade
{
    public int TradeId { get; set; }

    public int FundId { get; set; }

    public int SecurityId { get; set; }

    public DateTime TradeDate { get; set; }

    public double Quantity { get; set; }

    public double Price { get; set; }

    public DateTime CreateDateTime { get; set; }

    public virtual Fund Fund { get; set; } = null!;

    public ISecurity Security => throw new NotImplementedException();

    public double MarketValue => throw new NotImplementedException();

    public double DeltaExposure => throw new NotImplementedException();

    public double Cost => throw new NotImplementedException();

    public double Commission => throw new NotImplementedException();

    IFund ITrade.Fund => throw new NotImplementedException();

    public double GetOpenDeltaExposure(bool isLong)
    {
        throw new NotImplementedException();
    }
}
