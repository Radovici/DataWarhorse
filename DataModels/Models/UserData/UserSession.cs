using System;
using System.Collections.Generic;

namespace DataModels.UserData;

public partial class UserSession
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public string Guid { get; set; } = null!;

    public DateTime Expiration { get; set; }

    public string Comment { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
