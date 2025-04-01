using DataModels.Interfaces;
using System;
using System.Collections.Generic;

namespace DataModels.SecurityMaster;

public partial class Currency : ICurrency
{
    public int Id { get; set; }

    public string Code { get; set; } = null!;

    public string Name { get; set; } = null!;
}
