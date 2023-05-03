using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Application.Exceptions;
public class RatingNotFoundException : ApplicationException
{
    public RatingNotFoundException(string name, object key) : base($"{name} for ({key}) was not found")
    {
        
    }
}
