using System;
using System.Collections.Generic;

namespace Doantotnghiep_62131842.Entity;

public partial class Phieudiemdanh
{
    public string DiemdanhId { get; set; } = null!;

    public string? ChildResumeId { get; set; }

    public DateTime? Ngayhoc { get; set; }

    public string? Namhoc { get; set; }
    public string? thang_namhoc { get; set; }


    public virtual Hocvien? ChildResume { get; set; }

}
