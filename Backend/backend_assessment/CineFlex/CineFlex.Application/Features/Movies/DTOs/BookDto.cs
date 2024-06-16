using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CineFlex.Application.Features.Movies.DTOs
{
    public class BookDto
    {
        public int MovieId {get; set; }
        public int cinemaId {get; set; }
        public int SeatNumber {get; set; }
    }
}