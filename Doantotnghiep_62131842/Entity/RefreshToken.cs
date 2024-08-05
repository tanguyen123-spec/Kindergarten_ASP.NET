using System;
using System.Collections.Generic;

namespace Doantotnghiep_62131842.Entity;

public partial class RefreshToken
{
    public Guid Id { get; set; }

    public string NguoidungUsername { get; set; } = null!;

    public string Token { get; set; } = null!;

    public string JwtId { get; set; } = null!;

    public bool IsUsed { get; set; }

    public bool IsRevoked { get; set; }

    public DateTime IssuedAt { get; set; }

    public DateTime ExpireAt { get; set; }

    public virtual User NguoidungUsernameNavigation { get; set; } = null!;
}
