using Microsoft.AspNetCore.Identity;
using System.Collections;

namespace CineFlex.Domain
{
    public class AppUser : IdentityUser
    {
        public enum UserRole
        {
            Admin,
            User
        }
        public UserRole Role { get; set; } = UserRole.User;

        public ICollection<CinemaEntity> Cinemas { get; set; } = new List<CinemaEntity>();

        public ICollection<SeatEntity> Seats { get; set; } = new List<SeatEntity>();

        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    }
}
