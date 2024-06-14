using System.ComponentModel.DataAnnotations;

namespace CineFlex.API.AuthDto
{
    public class RegisterDto
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [RegularExpression("(?=.*\\d)(?=.*[a-z])(?=.*[A-Z]).{4,8}$", ErrorMessage = "Password please provide the correct password ")]

        public string Password { get; set; }

    }
}