using System;
using System.Collections.Generic;

namespace Doantotnghiep_62131842.Entity;

public partial class ChitietgiaovienLop
{
    public string ChitietgvLId { get; set; } = null!;

    public string? Magiaovien { get; set; }

    public string? ClassId { get; set; }

    public string? Namhoc { get; set; }

    public virtual Lop? Class { get; set; }

    public virtual Giaovien? MagiaovienNavigation { get; set; }
}
