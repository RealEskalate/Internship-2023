namespace CineFlex.Application.Features.Cinema.DTO;

public class CreateCinemaDto : ICinemaDto
{
    public string Name { get; set; }
    public string Location { get; set; }
    public string ContactInformation { get; set; }
}