using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.Application.Features.Review.DTOs
{
    public interface IReviewDto
    {
        public bool? IsResolved { get; set; }
    }
}