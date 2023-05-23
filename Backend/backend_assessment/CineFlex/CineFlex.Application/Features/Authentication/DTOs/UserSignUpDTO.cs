using System.ComponentModel.DataAnnotations;

namespace CineFlex.Application.Features.Authentication.DTOs{

    public class UserSignUpDTO
    {
        public string? FirstName { get; init; }
        public string? LastName { get; init; }

        [Required(ErrorMessage = "Email is required")]
        public string Email { get; init; }
        
        [Required(ErrorMessage = "Username is required")]
        public string Username { get; init; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; init; }

    }
}
