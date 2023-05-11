using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Application.Exceptions
{
    public class NetworkException : Exception
    {
        public NetworkException(string message) : base(message)
        {
        }
    }
}
