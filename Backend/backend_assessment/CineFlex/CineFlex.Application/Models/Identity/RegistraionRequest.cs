using System.ComponentModel.DataAnnotations;

namespace CineFlex.Application.Models.Identity;
public class RegistrationRequest
{
	
	[Required]
	public string Name { get; set; }

	[Required]
	[EmailAddress]
	public string Email { get; set; }

	[Required]
	[MinLength(8)]
	[RegularExpression(@"^(?=.*\d)(?=.*\W).+$", ErrorMessage = "The password must contain at least one special character and one number.")] 
	public string Password { get; set; }
} 