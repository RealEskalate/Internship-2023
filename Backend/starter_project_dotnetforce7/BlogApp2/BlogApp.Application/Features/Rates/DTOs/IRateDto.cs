using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Application.Features.Rates.DTOs
{
    public interface IRateDto
    {
        public int RaterId { get; set; }
        public int BlogId { get; set; }
        public int RateNo { get; set; }
    }
}
