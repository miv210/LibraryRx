using System;
using System.Collections.Generic;

namespace Library.Models;

public partial class Reader
{
    public int Id { get; set; }

    public string? Fullname { get; set; }

    public virtual ICollection<IssuanceOfBook> IssuanceOfBooks { get; } = new List<IssuanceOfBook>();
}
