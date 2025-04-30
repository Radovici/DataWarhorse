namespace DataModels.MarketData;

public partial class OptionPrice
{
    public int SecurityId { get; private set; }

    public int? SourceId { get; private set; }

    public DateOnly Date { get; private set; }

    public double Last { get; private set; }

    public double Bid { get; private set; }

    public double Ask { get; private set; }

    public double Volume { get; private set; }

    public double OpenInterest { get; private set; }

    public double ImpliedVolatility { get; private set; }

    public double Delta { get; private set; }

    public double Gamma { get; private set; }

    public double Theta { get; private set; }

    public double Vega { get; private set; }
}
