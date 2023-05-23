using CineFlex.Application.Features.Common;

namespace CineFlex.Application.Features.Cinema.Dtos
{
    public class CinemaProfile : BaseDto
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public string ContactInformation { get; set; }
    }
}
