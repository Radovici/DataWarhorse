using System;
using System.Collections.Generic;

namespace DataModels.UserData;

public partial class User
{
    public int Id { get; set; }

    public string Email { get; set; } = null!;

    public string? Settings { get; set; }

    public virtual ICollection<CustomSecurityAttribute> CustomSecurityAttributes { get; set; } = new List<CustomSecurityAttribute>();

    public virtual ICollection<UserSession> UserSessions { get; set; } = new List<UserSession>();
}
