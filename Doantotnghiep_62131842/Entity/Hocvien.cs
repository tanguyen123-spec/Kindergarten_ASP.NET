using System;
using System.Collections.Generic;

namespace Doantotnghiep_62131842.Entity;

public partial class Hocvien
{
    public string ChildResumeId { get; set; } = null!;

    public string? ParentResumeId { get; set; }

    public string? AfaId { get; set; }

    public string? ClassId { get; set; }

    public string? Name { get; set; }

    public string? Diachi { get; set; }

    public bool? Gender { get; set; }

    public string? MedicalHistory { get; set; }

    public string? InformationDif { get; set; }

    public string? CurrentHealthStatus { get; set; }

    public string? ImageUrl { get; set; }

    public virtual Donnhaphoc? Afa { get; set; }

    public virtual Lop? Class { get; set; }

    public virtual Phuhuynh? ParentResume { get; set; }
    public int Chiphibandau { get; set; }

    public virtual ICollection<Phieubengoan> Phieubengoans { get; set; } = new List<Phieubengoan>();

    public virtual ICollection<Phieudiemdanh> Phieudiemdanhs { get; set; } = new List<Phieudiemdanh>();

    public virtual ICollection<Suckhoedinhki> Suckhoedinhkis { get; set; } = new List<Suckhoedinhki>();

    public virtual ICollection<Tinhtrangsuckhoe> Tinhtrangsuckhoes { get; set; } = new List<Tinhtrangsuckhoe>();
}
