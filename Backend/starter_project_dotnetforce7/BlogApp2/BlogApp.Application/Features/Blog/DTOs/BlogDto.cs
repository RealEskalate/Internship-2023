using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogApp.Application.Features.Common;
using BlogApp.Application.Features.Rates.DTOs;
using BlogApp.Domain;
using Microsoft.AspNetCore.Http;

namespace BlogApp.Application.Features.Blogs.DTOs
{
    public class BlogDto : BaseDto, IBlogDto
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string? CoverImage { get; set; }
        public bool? PublicationStatus { get; set; }

        public double BlogRate { get; set; }

    }
}
