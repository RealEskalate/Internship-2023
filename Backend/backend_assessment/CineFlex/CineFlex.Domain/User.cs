using CineFlex.Domain.Common;

namespace CineFlex.Domain;

public enum UserRole
    {
    Admin,User
    }
    public class User : BaseDomainEntity
    {
        public string Username { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }


    }
    