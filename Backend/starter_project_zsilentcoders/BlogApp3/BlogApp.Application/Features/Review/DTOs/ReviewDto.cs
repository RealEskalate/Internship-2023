using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogApp.Application.Features.Common;

namespace BlogApp.Application.Features.Review.DTOs
{
    public class ReviewDto: BaseDto, IReviewDto
    {
        public int ReviewerId { get; set; }
        public string Comment { get; set; } = "";
        public int BlogId { get; set; }
        public bool? IsResolved { get; set; } = false;
    }
}