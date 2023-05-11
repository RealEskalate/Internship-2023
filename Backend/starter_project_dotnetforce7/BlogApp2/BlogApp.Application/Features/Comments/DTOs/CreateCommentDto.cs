using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogApp.Application.Features.Comments.DTOs;

namespace BlogApp.Application.Features.Comments.DTOs
{
    public class CreateCommentDto : ICommentDto
    {
        public string Content { get; set; }
        public int UserId { get; set; }

        public int BlogId { get; set; }
    }
}
