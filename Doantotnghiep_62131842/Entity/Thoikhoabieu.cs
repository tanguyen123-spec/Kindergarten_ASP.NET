using System;
using System.Collections.Generic;

namespace Doantotnghiep_62131842.Entity;

public partial class Thoikhoabieu
{
    public string Matkb { get; set; } = null!;

    public string? ClassId { get; set; }

    public string? Magiaovien { get; set; }

    public DateTime? Ngaybatdau { get; set; }

    public DateTime? Ngayketthuc { get; set; }

    public virtual Giaovien? MagiaovienNavigation { get; set; }

    public virtual ICollection<Tiethoc> Tiethocs { get; set; } = new List<Tiethoc>();
}
