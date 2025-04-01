namespace DataModels.MarketData;

public partial class Source {
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int Priority { get; set; }
}
