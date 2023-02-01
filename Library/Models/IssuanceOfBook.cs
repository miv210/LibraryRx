using System;
using System.Collections.Generic;

namespace Library.Models;

public partial class IssuanceOfBook
{
    public int Id { get; set; }

    public int IdReader { get; set; }

    public int IdBook { get; set; }

    public DateOnly? DateOfIssue { get; set; }

    public DateOnly? ReturnDate { get; set; }

    public virtual Book IdBookNavigation { get; set; } = null!;

    public virtual Reader IdReaderNavigation { get; set; } = null!;
}
