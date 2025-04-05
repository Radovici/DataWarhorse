namespace DataModels.MarketData;

public partial class Source
{
    public int Id { get; private set; }

    public string Name { get; private set; } = null!;

    public int Priority { get; private set; }
}
