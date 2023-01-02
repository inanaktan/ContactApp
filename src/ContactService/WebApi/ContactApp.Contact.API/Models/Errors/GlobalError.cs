using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactApp.Contact.API.Models.Errors;

public class GlobalError
{
    public GlobalError(string message)
    {
        this.Message = message;
    }
    
    public string Message { get; set; }
}
