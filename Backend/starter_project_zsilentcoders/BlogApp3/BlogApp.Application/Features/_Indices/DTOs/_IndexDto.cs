using BlogApp.Application.Features.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Application.Features._Indices.DTOs
{
    public class _IndexDto : BaseDto, I_IndexDto
    {
        public string Name { get; set; }
    }
}
