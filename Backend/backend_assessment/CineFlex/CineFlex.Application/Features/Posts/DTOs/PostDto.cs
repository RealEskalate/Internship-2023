using CineFlex.Application.Features.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Application.Features.Posts.DTOs
{
    public class PostDto : BaseDto, IPostDto
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public int PostUserId { get; set; }
    }
}
