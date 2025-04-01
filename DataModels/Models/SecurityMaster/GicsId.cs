using System;
using System.Collections.Generic;

namespace DataModels.SecurityMaster;

public partial class GicsId
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }
}
