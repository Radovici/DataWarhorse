using System;
using System.Collections.Generic;

namespace DataModels.PositionData;

public partial class Trade
{
    public int TradeId { get; set; }

    public int FundId { get; set; }

    public int SecurityId { get; set; }

    public DateTime TradeDate { get; set; }

    public double Quantity { get; set; }

    public double Price { get; set; }

    public DateTime CreateDateTime { get; set; }

    public virtual Fund Fund { get; set; } = null!;
}
