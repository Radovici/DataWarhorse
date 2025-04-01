namespace DataModels.MetaData;

public partial class PriceTargetNotification {
    public int Id { get; set; }

    public int PriceTargetId { get; set; }

    public DateTime CreateDateTime { get; set; }

    public double Price { get; set; }

    public virtual PriceTarget PriceTarget { get; set; } = null!;
}
