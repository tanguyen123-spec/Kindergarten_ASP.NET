using System;
using System.Collections.Generic;

namespace Doantotnghiep_62131842.Entity;

public partial class Giaovien
{
    public string Magiaovien { get; set; } = null!;

    public string? Maloaigiaovien { get; set; }

    public string? Tengiaovien { get; set; }

    public DateTime? Ngaysinh { get; set; }

    public string? Diachi { get; set; }

    public string? Sodienthoai { get; set; }

    public string? ImageUrl { get; set; }

    public virtual ICollection<ChitietgiaovienLop> ChitietgiaovienLops { get; set; } = new List<ChitietgiaovienLop>();

    public virtual Loaigiaovien? MaloaigiaovienNavigation { get; set; }

    public virtual ICollection<Phieubengoan> Phieubengoans { get; set; } = new List<Phieubengoan>();

    public virtual ICollection<Suckhoedinhki> Suckhoedinhkis { get; set; } = new List<Suckhoedinhki>();

    public virtual ICollection<Thoikhoabieu> Thoikhoabieus { get; set; } = new List<Thoikhoabieu>();

    public virtual ICollection<Tinhtrangsuckhoe> Tinhtrangsuckhoes { get; set; } = new List<Tinhtrangsuckhoe>();

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
