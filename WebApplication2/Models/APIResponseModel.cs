using System;
using System.Collections.Generic;

namespace WebApplication2.Models;

public partial class APIResponseModel<T> where T : class
{
    public bool SusseccStatus { get; set; }

    public T ReturnData { get; set; } 

    public string? ReturnMessage { get; set; }

    

}
