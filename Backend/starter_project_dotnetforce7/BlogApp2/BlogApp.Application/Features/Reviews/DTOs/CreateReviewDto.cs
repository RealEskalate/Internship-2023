using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Application.Features.Reviews.DTOs
{
    public class CreateReviewDto : IReviewDto
    {
        public int ReviewerId { get; set; }
        public string ReviewContent { get; set; }
        public int BlogId { get; set; }
        public bool? isResolved { get; set; }
    }
}
