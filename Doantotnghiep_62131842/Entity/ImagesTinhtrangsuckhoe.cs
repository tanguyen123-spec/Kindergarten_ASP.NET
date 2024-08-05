using System;
using System.Collections.Generic;

namespace Doantotnghiep_62131842.Entity;

public partial class ImagesTinhtrangsuckhoe
{
    public string ImagesTinhtrangsuckhoeId { get; set; } = null!;

    public string? TtskId { get; set; }
    public string? LinkImage { get; set; }

    public virtual Tinhtrangsuckhoe? Ttsk { get; set; }
}
