namespace DataModels.MetaData;

public partial class TargetDirection {
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Target> Targets { get; set; } = new List<Target>();
}
