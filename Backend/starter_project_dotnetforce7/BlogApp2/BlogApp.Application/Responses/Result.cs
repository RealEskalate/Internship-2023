using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Application.Responses
{
    public class Result<T>
    {
        public bool Success { get; set; } = true;
        public string Message { get; set; }
        public T? Value { get; set; }
        public List<string> Errors { get; set; }
    }
}
