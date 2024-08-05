using System;
using System.Collections.Generic;

namespace Doantotnghiep_62131842.Entity;

public partial class Tiethoc
{
    public string Tiethocid { get; set; } = null!;

    public string? Matkb { get; set; }

    public DateTime? Thoigianbatdauhoc { get; set; }

    public DateTime? Thoigianketthuchoc { get; set; }

    public DateTime? Ngayhoc { get; set; }

    public string? Tieuthoc { get; set; }

    public virtual Thoikhoabieu? MatkbNavigation { get; set; }
}
