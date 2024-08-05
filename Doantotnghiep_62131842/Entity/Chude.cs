using System;
using System.Collections.Generic;

namespace Doantotnghiep_62131842.Entity;

public partial class Chude
{
    public string Machude { get; set; } = null!;

    public string? Tenchude { get; set; }

    public virtual ICollection<Ykien> Ykiens { get; set; } = new List<Ykien>();
}
