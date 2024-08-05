using System;
using System.Collections.Generic;

namespace Doantotnghiep_62131842.Entity;

public partial class Donnhaphoc
{
    public string AfaId { get; set; } = null!;

    public string? Lophocmongmuon { get; set; }

    public string? Namhoc { get; set; }

    public DateTime? Batdauhoc { get; set; }

    public bool? Status { get; set; }

    public DateTime? Ngaytaodon { get; set; }

    public string? SdtLienhe { get; set; }
    public string? Name { get; set; }

    public virtual ICollection<Hocvien> Hocviens { get; set; } = new List<Hocvien>();
}
