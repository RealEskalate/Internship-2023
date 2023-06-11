﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Application.Responses
{
    public class Result<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public T? Value { get; set; }
        public List<string> Errors { get; set; }
    }
}
