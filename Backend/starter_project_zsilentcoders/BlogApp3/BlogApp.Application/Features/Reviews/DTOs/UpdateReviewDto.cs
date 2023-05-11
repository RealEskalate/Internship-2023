using BlogApp.Application.Features.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Application.Features.Reviews.DTOs
{
    public class UpdateReviewDto: BaseDto, IReviewDto
    {
        public int ReviewerId { get; set; }
        public string Comment { get; set; } = "";
        public bool? IsResolved { get; set; } = false;
    }
}
