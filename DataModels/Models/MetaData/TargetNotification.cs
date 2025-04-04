namespace DataModels.Metadata;

public partial class TargetNotification {
    public int Id { get; set; }

    public int TargetId { get; set; }

    public double Value { get; set; }

    public DateTime CreateDateTime { get; set; }

    public virtual Target Target { get; set; } = null!;
}
