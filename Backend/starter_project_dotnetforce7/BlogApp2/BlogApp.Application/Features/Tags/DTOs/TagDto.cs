using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogApp.Application.Features.Common;

namespace BlogApp.Application.Features.Tags.DTOs
{
    public class TagDto : BaseDto, ITagDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }
}