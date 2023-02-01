using System;
using System.Collections.Generic;

namespace Library.Models;

public partial class Reader
{
    public int Id { get; set; }

    public string Fullname { get; set; } = null!;

    public virtual IssuanceOfBook? IssuanceOfBook { get; set; }
}
