using System;
using System.Collections.Generic;

namespace Doantotnghiep_62131842.Entity;

public partial class Tinhtrangsuckhoe
{
    public string TtskId { get; set; } = null!;

    public string? ChildResumeId { get; set; }

    public string? Magiaovien { get; set; }

    public DateTime? Ngaykiemtra { get; set; }

    public string? Nhietdo { get; set; }

    public string? Trangthaian { get; set; }

    public string? Trangthaingu { get; set; }

    public string? Thaidohochanh { get; set; }

    public virtual Hocvien? ChildResume { get; set; }

    public virtual ICollection<ImagesTinhtrangsuckhoe> ImagesTinhtrangsuckhoes { get; set; } = new List<ImagesTinhtrangsuckhoe>();

    public virtual Giaovien? MagiaovienNavigation { get; set; }
}
