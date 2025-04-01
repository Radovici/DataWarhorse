using System;
using System.Collections.Generic;

namespace DataModels.SecurityMaster;

public partial class SecurityType
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Security> Securities { get; set; } = new List<Security>();
}
