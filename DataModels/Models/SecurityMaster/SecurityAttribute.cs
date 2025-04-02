namespace DataModels.SecurityMaster;

public partial class SecurityAttribute
{
    public int SecurityId { get; set; }

    public int SecurityAttributeTypeId { get; set; }

    public DateOnly Date { get; set; }

    public string Value { get; set; } = null!;

    public DateTime CreateDateTime { get; set; }

    public virtual Security Security { get; set; } = null!;

    public virtual SecurityAttributeType SecurityAttributeType { get; set; } = null!;
}
