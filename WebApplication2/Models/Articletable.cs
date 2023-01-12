using System;
using System.Collections.Generic;

namespace WebApplication2.Models;

public partial class Articletable
{
    public string PostAccount { get; set; } = null!;

    public string PostContent { get; set; } = null!;

    public string? PostTitle { get; set; }

    public DateTime? PostDatetime { get; set; }

    public int RowId { get; set; }
}
