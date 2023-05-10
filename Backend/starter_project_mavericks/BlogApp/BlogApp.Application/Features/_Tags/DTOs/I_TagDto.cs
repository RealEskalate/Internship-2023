using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Application.Features._Tags.DTOs
{
    public interface I_TagDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
