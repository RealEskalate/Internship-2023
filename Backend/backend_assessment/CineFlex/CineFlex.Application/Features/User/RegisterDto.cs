using System.ComponentModel.DataAnnotations;

namespace CineFlex.Application.Features.User
{
    public class RegisterDto
    {

        [Required]
        public string FullName { get; set; }

        [Required]
        // [RegularExpression("(?=.*\\d)(?=.*[a-z])(?=.*[A-Z]).{4,8}$", ErrorMessage = "Password must be complex")]

        public string Password { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

    }
}