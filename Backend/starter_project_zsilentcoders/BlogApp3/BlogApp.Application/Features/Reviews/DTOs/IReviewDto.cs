using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.Application.Features.Reviews.DTOs
{
    public interface IReviewDto
    {
        public bool? IsResolved { get; set; }
    }
}