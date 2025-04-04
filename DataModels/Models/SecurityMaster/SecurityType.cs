namespace DataModels.SecurityMaster;

public partial class SecurityType
{
    public int Id { get; private set; }

    public string Name { get; private set; } = null!;

    public virtual ICollection<Security> Securities { get; private set; } = new List<Security>();
}
