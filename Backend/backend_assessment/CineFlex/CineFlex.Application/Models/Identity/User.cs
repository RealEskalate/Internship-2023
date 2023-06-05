using CineFlex.Domain.Common;

namespace CineFlex.Domain.Models.Identity
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string password { get; set; }
    }
}