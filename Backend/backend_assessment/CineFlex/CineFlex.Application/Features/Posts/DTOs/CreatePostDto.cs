using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CineFlex.Application.Features.Common;

namespace CineFlex.Application.Features.Posts.DTOs
{
    public class CreatePostDto
    {

        public string Title{get;set;}
        public string Content{get;set;}
        public int UserId{get;set;}

        
    }
}