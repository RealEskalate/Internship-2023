using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Application.Features.Tags.DTOs
{
    public class createTagDto : ITagDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
