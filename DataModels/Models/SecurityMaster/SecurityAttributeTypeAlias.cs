using System;
using System.Collections.Generic;

namespace DataModels.SecurityMaster;

public partial class SecurityAttributeTypeAlias
{
    public int SecurityAttributeTypeId { get; set; }

    public string Name { get; set; } = null!;

    public string Source { get; set; } = null!;

    public DateTime CreateDateTime { get; set; }

    public virtual SecurityAttributeType SecurityAttributeType { get; set; } = null!;
}
