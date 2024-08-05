using System;
using System.Collections.Generic;

namespace Doantotnghiep_62131842.Entity;

public partial class Phuhuynh
{
    public string ParentResumeId { get; set; } = null!;

    public string? NameP { get; set; }

    public DateTime? DateOfBirth { get; set; }

    public string? Phone1 { get; set; }

    public string? Phone2 { get; set; }

    public string? NameP2 { get; set; }

    public string? Diachi { get; set; }

    public bool? Gender { get; set; }

    public string? JobParent { get; set; }

    public int? NumberOfChildren { get; set; }

    public string? ImageUrl { get; set; }

    public virtual ICollection<Hocvien> Hocviens { get; set; } = new List<Hocvien>();

    public virtual ICollection<User> Users { get; set; } = new List<User>();

    public virtual ICollection<Ykien> Ykiens { get; set; } = new List<Ykien>();
}
