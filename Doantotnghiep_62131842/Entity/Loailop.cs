using System;
using System.Collections.Generic;

namespace Doantotnghiep_62131842.Entity;

public partial class Loailop
{
    public string ClasstypeId { get; set; } = null!;

    public string? NameClasstype { get; set; }

    public virtual ICollection<Lop> Lops { get; set; } = new List<Lop>();
}
