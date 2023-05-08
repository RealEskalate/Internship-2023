using BlogApp.Application.Features.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Application.Features.Comments.DTOs
{
    public class UpdateCommentDto : BaseDto
    {
        public string Commenter { get; set; }

        public string Content { get; set; }

        
    }
}
