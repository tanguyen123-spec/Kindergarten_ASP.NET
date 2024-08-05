using System;
using System.Collections.Generic;

namespace Doantotnghiep_62131842.Entity;

public partial class Loaigiaovien
{
    public string Maloaigiaovien { get; set; } = null!;

    public string? Tenloaigiaovien { get; set; }

    public virtual ICollection<Giaovien> Giaoviens { get; set; } = new List<Giaovien>();
}
