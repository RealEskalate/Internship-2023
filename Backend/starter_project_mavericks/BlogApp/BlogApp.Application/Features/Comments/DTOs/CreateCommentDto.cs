using BlogApp.Application.Features.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Application.Features.Comments.DTOs
{
    public class CreateCommentDto : BaseDto, ICommentDto
    {
        public string Commenter { get; set; }

        public string Content { get; set; }

        public string BlogId { get; set; }
    }
}
