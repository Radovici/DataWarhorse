namespace DataModels.SecurityMaster;

public partial class SecurityAttributeTypeAlias
{
    public int SecurityAttributeTypeId { get; private set; }

    public string Name { get; private set; } = null!;

    public string Source { get; private set; } = null!;

    public DateTime CreateDateTime { get; private set; }

    public virtual SecurityAttributeType SecurityAttributeType { get; private set; } = null!;
}
