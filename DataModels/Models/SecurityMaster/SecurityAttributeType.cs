using System;
using System.Collections.Generic;

namespace DataModels.SecurityMaster;

public partial class SecurityAttributeType
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<SecurityAttributeTypeAlias> SecurityAttributeTypeAliases { get; set; } = new List<SecurityAttributeTypeAlias>();

    public virtual ICollection<SecurityAttribute> SecurityAttributes { get; set; } = new List<SecurityAttribute>();
}
