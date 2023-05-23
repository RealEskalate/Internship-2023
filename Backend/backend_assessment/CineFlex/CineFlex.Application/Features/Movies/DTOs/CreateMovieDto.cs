namespace CineFlex.Application.Features.Movies.DTOs;

public class CreateMovieDto : IMovieDto
{
    public string Title { get; set; }
    public string Genre { get; set; }
    public string ReleaseYear { get; set; }
}