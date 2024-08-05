using System;
using System.Collections.Generic;

namespace Doantotnghiep_62131842.Entity;

public partial class Suckhoedinhki
{
    public string SkdkId { get; set; } = null!;

    public string? Magiaovien { get; set; }

    public string? ChildResumeId { get; set; }

    public DateTime? Ngaykiemtra { get; set; }

    public string? Chieucao { get; set; }

    public string? Cannang { get; set; }

    public string? Benhlykhac { get; set; }

    public string? Ghichubacsy { get; set; }

    public DateTime? NgayTao { get; set; }

    public virtual Hocvien? ChildResume { get; set; }

    public virtual Giaovien? MagiaovienNavigation { get; set; }
}
