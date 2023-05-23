using CineFlex.Domain.Common;

namespace CineFlex.Domain;

public class Seat : BaseDomainEntity
{
    public int CinemaId { get; set; }
    public string Name { get; set; } = null!;
}