using System;
using System.Collections.Generic;

namespace WebApplication2.Models;

public partial class Logintable
{
    public int RowId { get; set; }

    public string? Account { get; set; }

    public string? Password { get; set; }

    public string? Name { get; set; }

    public int? Phone { get; set; }
}
