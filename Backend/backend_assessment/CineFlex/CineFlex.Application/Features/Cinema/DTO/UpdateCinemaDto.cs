using CineFlex.Application.Features.Common;

namespace CineFlex.Application.Features.Cinema.DTO;

public class UpdateCinemaDto : BaseDto, ICinemaDto
{
    public string Name { get; set; }
    public string Location { get; set; }
    public string ContactInformation { get; set; }
}