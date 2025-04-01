namespace DataModels.MarketData;

public partial class EquitySplit
{
    internal int SecurityId { get; private set; }

    public DateTime Date { get; private set; }

    public double Ratio { get; private set; }
}
