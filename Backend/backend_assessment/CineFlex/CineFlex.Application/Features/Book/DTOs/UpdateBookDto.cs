using CineFlex.Application.Features.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Application.Features.Book.DTOs
{
    public class UpdateBookDto: BaseDto,  IBookDto
    {
        public string Cinima { get; set; }
        public string Movie { get; set; }
        public string Seat { get; set; }
    }
}
