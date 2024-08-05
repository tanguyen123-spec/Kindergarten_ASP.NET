using System;
using System.Collections.Generic;

namespace Doantotnghiep_62131842.Entity;

public partial class Ykien
{
    public string OpinionId { get; set; } = null!;

    public string? Machude { get; set; }

    public string? ParentResumeId { get; set; }

    public string? NoteOpinion { get; set; }

    public string? Giaiphap { get; set; }

    public virtual Chude? MachudeNavigation { get; set; }

    public virtual Phuhuynh? ParentResume { get; set; }
}
