using CineFlex.Domain.Common;

namespace CineFlex.Domain;

public class CineFlexUser : BaseDomainEntity
{
    public string AppUserId { get; set; }
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string Role { get; set; }
}