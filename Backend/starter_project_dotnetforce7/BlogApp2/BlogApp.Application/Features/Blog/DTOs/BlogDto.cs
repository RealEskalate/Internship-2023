using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogApp.Application.Features.Common;

namespace BlogApp.Application.Features.Blogs.DTOs
{
    public class BlogDto : BaseDto, IBlogDto
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string CoverImage { get; set; }
        public bool? PublicationStatus { get; set; }
    }
}