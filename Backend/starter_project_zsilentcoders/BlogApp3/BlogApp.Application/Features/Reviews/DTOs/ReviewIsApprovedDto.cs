using BlogApp.Application.Features.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Application.Features.Reviews.DTOs
{
    public class ReviewIsApprovedDto: BaseDto
    {
        public bool? IsApproved { get; set; }
    }
}
