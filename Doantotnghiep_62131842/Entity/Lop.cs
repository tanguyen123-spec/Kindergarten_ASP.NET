using System;
using System.Collections.Generic;

namespace Doantotnghiep_62131842.Entity;

public partial class Lop
{
    public string ClassId { get; set; } = null!;

    public string? ClasstypeId { get; set; }

    public string? NameClass { get; set; }

    public int? Siso { get; set; }

    public string? Namhoc { get; set; }

    public virtual ICollection<ChitietgiaovienLop> ChitietgiaovienLops { get; set; } = new List<ChitietgiaovienLop>();

    public virtual Loailop? Classtype { get; set; }

    public virtual ICollection<Hocvien> Hocviens { get; set; } = new List<Hocvien>();
}
