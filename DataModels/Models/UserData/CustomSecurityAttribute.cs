using System;
using System.Collections.Generic;

namespace DataModels.UserData;

public partial class CustomSecurityAttribute
{
    public int UserId { get; set; }

    public int SecurityId { get; set; }

    public int SecurityAttributeTypeId { get; set; }

    public DateOnly Date { get; set; }

    public DateOnly? Expiry { get; set; }

    public string Value { get; set; } = null!;

    public DateTime CreateDateTime { get; set; }

    public virtual User User { get; set; } = null!;
}
