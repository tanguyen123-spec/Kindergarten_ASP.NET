using System;
using System.Collections.Generic;

namespace Doantotnghiep_62131842.Entity;

public partial class DsthucDon
{
    public string MenuId { get; set; } = null!;

    public DateTime? Ngaybatdau { get; set; }

    public DateTime? Ngayketthuc { get; set; }

    public virtual ICollection<Danhmonantheongay> Danhmonantheongays { get; set; } = new List<Danhmonantheongay>();
}
