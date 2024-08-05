using System;
using System.Collections.Generic;

namespace Doantotnghiep_62131842.Entity;

public partial class Danhmonantheongay
{
    public string Malichngay { get; set; } = null!;

    public string? MenuId { get; set; }

    public DateTime? Ngay { get; set; }

    public string? Buoisang { get; set; }

    public string? Buoitrua { get; set; }

    public string? Buoichieu { get; set; }

    public string? Trangmieng { get; set; }

    public virtual DsthucDon? Menu { get; set; }
}
