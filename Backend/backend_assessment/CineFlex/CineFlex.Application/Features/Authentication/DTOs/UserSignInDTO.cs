using System.ComponentModel.DataAnnotations;

namespace CineFlex.Application.Features.Authentication.DTOs{

    public class UserSignInDTO
    {
        [Required(ErrorMessage = "Email is required")]
        public string Username { get; init; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; init; }
    }
}
