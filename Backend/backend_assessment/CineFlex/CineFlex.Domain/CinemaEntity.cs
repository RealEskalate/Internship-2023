using CineFlex.Domain.Common;

namespace CineFlex.Domain
{
    public class CinemaEntity:BaseDomainEntity
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public string ContactInformation { get; set; }
        public ICollection<Seat> Seats { get; set; }
        public ICollection<Movie> Movies { get; set; }
    }
}
