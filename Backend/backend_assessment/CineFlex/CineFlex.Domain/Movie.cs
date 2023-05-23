using CineFlex.Domain.Common;

namespace CineFlex.Domain;

public class Movie : BaseDomainEntity
{
    public string Title { get; set; }
    public string Genre { get; set; }
    public string ReleaseYear { get; set; }
}