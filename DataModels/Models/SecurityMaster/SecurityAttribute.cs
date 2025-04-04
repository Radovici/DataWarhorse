using DataModels.Interfaces;

namespace DataModels.SecurityMaster;

public partial class SecurityAttribute
{
    public int SecurityId { get; private set; }

    public int SecurityAttributeTypeId { get; private set; }

    public DateOnly Date { get; private set; }

    public string Value { get; private set; } = null!;

    public DateTime CreateDateTime { get; private set; }

    public Security _security { get; private set; } = null!;

    public ISecurity Security => _security;

    public SecurityAttributeType SecurityAttributeType { get; private set; } = null!;
}
