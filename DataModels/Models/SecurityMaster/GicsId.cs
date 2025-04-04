namespace DataModels.SecurityMaster;

public partial class GicsId
{
    public int Id { get; private set; }

    public string Name { get; private set; } = null!;

    public string? Description { get; private set; }
}
