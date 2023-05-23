using System.ComponentModel.DataAnnotations;

namespace CineFlex.Application.Features.Authentication.DTOs{

    public class UserDTO
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }    
        public string Email { get; init; }
    }
}
