namespace DataModels.MarketData;

public partial class OptionPrice {
    public int SecurityId { get; set; }

    public int? SourceId { get; set; }

    public DateTime Date { get; set; }

    public double Last { get; set; }

    public double Bid { get; set; }

    public double Ask { get; set; }

    public double Volume { get; set; }

    public double OpenInterest { get; set; }

    public double ImpliedVolatility { get; set; }

    public double Delta { get; set; }

    public double Gamma { get; set; }

    public double Theta { get; set; }

    public double Vega { get; set; }
}
