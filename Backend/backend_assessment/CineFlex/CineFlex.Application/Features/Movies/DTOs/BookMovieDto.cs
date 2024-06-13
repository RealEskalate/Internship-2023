using System;
using System.Collections.Generic;

namespace CineFlex.Application.Features.Movies.DTOs
{
    public class BookMovieDto
    {
        public string MovieId { get; set; }
        public string CinemaId { get; set; }
        public List<string> Seats { get; set; }
    }
}
