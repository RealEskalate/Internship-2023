using System.Security.Claims;
using CineFlex.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CineFlex.API.Controllers;

public class UsersController: BaseApiController
{

    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;
    
    public UsersController(UserManager<User> userManager, SignInManager<User> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }
    
    [HttpPost("/login")]
    public async Task<ActionResult> Login([FromBody] LoginInfo loginInfo)
    {
        var user = await _userManager.FindByEmailAsync(email: loginInfo.email);
        
        if (user == null)
            return NotFound("User not found");
        
        var signInResult = await _signInManager.PasswordSignInAsync(user, loginInfo.password, false, false);
        
        if (signInResult.Succeeded)
            return Ok("SUCCEEDED");
        
        return Ok("DENIED");
    }
    
    [HttpPost("/signup")]
    public async Task<ActionResult> Signup([FromBody] SignupInfo signupInfo)
    {
        var newUser = new User { UserName = signupInfo.username, Email = signupInfo.email};
        
        var result = await _userManager.CreateAsync(newUser, signupInfo.password);
        
        if (result.Succeeded)
        {
            var claimResult = await _userManager.AddClaimAsync(newUser, new Claim("Role", "User"));
            
            if (claimResult.Succeeded)
                return Ok("Created");
        }
        
        return Ok(result.Errors.First().Description);
    }

    public class LoginInfo
    {
        public string email { get; set; }
        public string password { get; set; }
    }
    
    public class SignupInfo
    {
        public string username { get; set; }
        public string email { get; set; }
        public string password { get; set; }
    }
    
}