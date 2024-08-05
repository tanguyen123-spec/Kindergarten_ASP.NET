using System;
using System.Collections.Generic;

namespace Doantotnghiep_62131842.Entity;

public partial class Phieubengoan
{
    public string PhbnId { get; set; } = null!;

    public string? ChildResumeId { get; set; }

    public string? Magiaovien { get; set; }

    public string? Hanhvi { get; set; }

    public string? Thaido { get; set; }

    public string? Thanhtich { get; set; }

    public DateTime? Ngaydanhgia { get; set; }

    public virtual Hocvien? ChildResume { get; set; }

    public virtual Giaovien? MagiaovienNavigation { get; set; }
}
