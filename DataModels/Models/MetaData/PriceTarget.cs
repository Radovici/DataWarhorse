namespace DataModels.Metadata;

public partial class PriceTarget
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int SecurityId { get; set; }

    public double? Price { get; set; }

    public DateTime? TargetDate { get; set; }

    public string? Notes { get; set; }

    public bool IsActive { get; set; }

    public int? Rearm { get; set; }

    public virtual ICollection<PriceTargetNotification> PriceTargetNotifications { get; set; } = new List<PriceTargetNotification>();

    public DateTime CreateDateTime { get; set; }
}
