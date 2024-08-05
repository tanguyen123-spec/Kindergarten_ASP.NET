using System;
using System.Collections.Generic;

namespace Doantotnghiep_62131842.Entity;

public partial class User
{
    public string UserId { get; set; } = null!;

    public string? Username { get; set; }

    public string? Mail { get; set; }

    public string? RoleId { get; set; }

    public string? Password { get; set; }

    public string? Magiaovien { get; set; }

    public string? ParentResumeId { get; set; }

    public virtual Giaovien? MagiaovienNavigation { get; set; }

    public virtual Phuhuynh? ParentResume { get; set; }

    public virtual ICollection<RefreshToken> RefreshTokens { get; set; } = new List<RefreshToken>();

    public virtual Role? Role { get; set; }
}
