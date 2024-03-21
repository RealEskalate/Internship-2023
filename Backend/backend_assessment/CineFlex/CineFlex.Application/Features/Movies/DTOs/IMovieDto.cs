using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Application.Features.Movies.DTOs
{
    public interface IMovieDto
    {
        public string Title { get; set; }
        public string Genre { get; set; }
        public string ReleaseYear { get; set; }
    }
}