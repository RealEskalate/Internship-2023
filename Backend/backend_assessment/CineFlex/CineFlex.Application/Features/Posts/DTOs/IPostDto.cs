using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Application.Features.Posts.DTOs
{
    public interface IPostDto
    {
        int Id { get; set; }
        string Title { get; set; }
        string Content { get; set; }
        int PostUserId { get; set; }
    }
}
