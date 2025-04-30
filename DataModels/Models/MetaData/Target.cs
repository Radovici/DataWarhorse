namespace DataModels.Metadata;

public partial class Target
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int? FundId { get; set; }

    public int? SecurityId { get; set; }

    public int TargetDirectionId { get; set; }

    public string Formula { get; set; } = null!;

    public double? Value { get; set; }

    public DateOnly? Date { get; set; }

    public string? Notes { get; set; }

    public bool IsActive { get; set; }

    public double? OriginalValue { get; set; }

    public DateTime CreateDateTime { get; set; }

    public virtual TargetDirection TargetDirection { get; set; } = null!;

    public virtual ICollection<TargetNotification> TargetNotifications { get; set; } = new List<TargetNotification>();
}
