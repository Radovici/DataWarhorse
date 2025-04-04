using DataModels.Interfaces;

namespace DataModels.SecurityMaster;

public partial class SecurityAttribute : ISecurityAttribute
{
    public int SecurityId { get; private set; }

    public int SecurityAttributeTypeId { get; private set; }

    public DateOnly Date { get; private set; }

    public string Value { get; private set; } = null!;

    public DateTime CreateDateTime { get; private set; }

    public Security Security { get; private set; } = null!;

    ISecurity ISecurityAttribute.Security => Security;

    public SecurityAttributeType SecurityAttributeType { get; private set; } = null!;

    public string Name => SecurityAttributeType.Name;

    DateOnly IDatedNameValuePair<string>.Date => Date;
}
