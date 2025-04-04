namespace DataModels.SecurityMaster;

public partial class SecurityAttributeType
{
    public int Id { get; private set; }

    public string Name { get; private set; } = null!;

    public virtual ICollection<SecurityAttributeTypeAlias> SecurityAttributeTypeAliases { get; private set; } = new List<SecurityAttributeTypeAlias>();

    public virtual ICollection<SecurityAttribute> SecurityAttributes { get; private set; } = new List<SecurityAttribute>();
}
