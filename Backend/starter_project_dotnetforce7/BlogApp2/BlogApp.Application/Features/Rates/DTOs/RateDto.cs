using BlogApp.Application.Features.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Application.Features.Rates.DTOs
{
    public class RateDto:BaseDto
    {
        public int RaterId { get; set; }
        public int BlogId { get; set; }
        public int RateNo { get; set; }
    }
}
