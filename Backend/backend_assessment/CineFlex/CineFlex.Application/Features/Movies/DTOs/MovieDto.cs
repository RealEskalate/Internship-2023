using CineFlex.Application.Features.Common;

namespace CineFlex.Application.Features.Movies.DTOs;

public class MovieDto : BaseDto, IMovieDto
{
    public string Title { get; set; }
    public string Genre { get; set; }
    public string ReleaseYear { get; set; }
}