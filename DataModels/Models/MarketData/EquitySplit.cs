namespace DataModels.MarketData;

public partial class EquitySplit
{
    public int SecurityId { get; private set; }

    public DateOnly Date { get; private set; }

    public double Ratio { get; private set; }
}
