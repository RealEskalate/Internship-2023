using System.Security.Claims;
using BlogApp.Application.Contracts.Identity;
using BlogApp.Application.Models.Identity;
using BlogApp.Application.Models.Mail;
using BlogApp.Application.Responses;
using BlogApp.Identity.Models;
using BlogApp.Identity.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Moq;
using Xunit;

namespace BlogApp.Identity.UnitTests;

public class AuthServiceTests
{
    #region  fields
    private readonly AuthService _authService;
    private readonly Mock<UserManager<BlogUser>> _userManagerMock;
    private readonly Mock<SignInManager<BlogUser>> _signInManagerMock;
    private readonly Mock<IEmailSender> _emailSenderMock;

    #endregion
    public AuthServiceTests()
    {
        _userManagerMock = new Mock<UserManager<BlogUser>>(Mock.Of<IUserStore<BlogUser>>(), null, null, null, null, null, null, null, null);
        _signInManagerMock = new Mock<SignInManager<BlogUser>>(_userManagerMock.Object, Mock.Of<IHttpContextAccessor>(), Mock.Of<IUserClaimsPrincipalFactory<BlogUser>>(), null, null, null, null);
        _emailSenderMock = new Mock<IEmailSender>();

        var jwtOptions =  Options.Create(new JwtSettings() 
        { 
            Key = "2J9JFA9THQTH9AHRHTQ9YAQTJ",
            Issuer = "BlogApi",
            Audience = "BlogApiUser",
            DurationInMinutes = 60
        });

        var serverOptions = Options.Create(new ServerSettings()
        {
            BaseApiUrl = "test"
        });

        _authService = new AuthService(_userManagerMock.Object, _signInManagerMock.Object, jwtOptions, serverOptions, _emailSenderMock.Object);
    }

    #region  Login tests
    [Fact]
    public async Task Login_ShouldReturnAuthResponse_WhenValidCredentialsProvided()
    {
        // Arrange
        var email = "user@example.com";
        var password = "Pa$$w0rd";
        var user = new BlogUser { Email = email, UserName = email };
        var authRequest = new LoginModel { Email = email, Password = password };

        _userManagerMock.Setup(u => u.FindByEmailAsync(email))
            .ReturnsAsync(user);
        _userManagerMock.Setup(u => u.GetClaimsAsync(user))
            .ReturnsAsync(new List<Claim>());
        _userManagerMock.Setup(u => u.GetRolesAsync(user))
            .ReturnsAsync(new List<string>());
        _signInManagerMock.Setup(s => s.PasswordSignInAsync(user.UserName, password, false, false))
            .ReturnsAsync(SignInResult.Success);

        // Act
        var result = await _authService.Login(authRequest);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(result.Success, true);
        Assert.NotNull(result.Value);
        Assert.Equal(user.Email, result.Value.Email);
        Assert.Equal(user.UserName, result.Value.UserName);
    }

    [Fact]
    public async Task Login_ShouldReturnFalse_WhenUserNotFound()
    {
        // Arrange
        var email = "user@example.com";
        var password = "Pa$$w0rd";
        var authRequest = new LoginModel { Email = email, Password = password };

        _userManagerMock.Setup(u => u.FindByEmailAsync(email))
            .ReturnsAsync((BlogUser)null);

        // Act & Assert
        var result = await _authService.Login(authRequest);

        Assert.NotNull(result);
        Assert.Equal(result.Success, false);
        Assert.Equal(result.Value, null);

    }

    [Fact]
    public async Task Login_ShouldReturnFalse_WhenInvalidCredentialsProvided()
    {
        // Arrange
        var email = "user@example.com";
        var password = "Pa$$w0rd";
        var user = new BlogUser { Email = email, UserName = email };
        var authRequest = new LoginModel { Email = email, Password = password };

        _userManagerMock.Setup(u => u.FindByEmailAsync(email))
            .ReturnsAsync(user);
        _signInManagerMock.Setup(s => s.PasswordSignInAsync(user.UserName, password, false, false))
            .ReturnsAsync(SignInResult.Failed);

        // Act & Assert
        var result = await _authService.Login(authRequest);

        Assert.NotNull(result);
        Assert.Equal(result.Success, false);
        Assert.Equal(result.Value, null);

    }

    #endregion


    #region Register tests
    [Fact]
    public async Task Register_ShouldReturnFalse_WhenExistingEmailFound()
    {
        // Arrange
        var request = new RegistrationModel
        {
            Email = "test@example.com",
            Password = "P@ssw0rd",
            UserName = "johndoe",
            Roles = new List<string>{"User"}
        };

        _userManagerMock
            .SetupSequence(x => x.FindByNameAsync(request.UserName))
            .ReturnsAsync(new BlogUser());

        _userManagerMock
            .Setup(x => x.FindByEmailAsync(request.Email))
            .ReturnsAsync(new BlogUser());

        // Act & Assert
        var result = await _authService.Register(request);

        Assert.NotNull(result);
        Assert.Equal(result.Success, false);
        Assert.Equal(result.Value, null);
    }

    [Fact]
    public async Task Register_ShouldReturnRegistrationResponse_WhenUserCreatedSuccessfully()
    {
        // Arrange
        var request = new RegistrationModel
        {
            Email = "test@example.com",
            Password = "P@ssw0rd",
            UserName = "johndoe",
            Roles = new List<string>{"User"}
        };

        var emailResult = new Result<Email>()
        {
            Success = true
        };

        _emailSenderMock.Setup(u => u.sendEmail(It.IsAny<Email>()))
            .ReturnsAsync(emailResult);

        _userManagerMock
            .SetupSequence(x => x.FindByEmailAsync(request.Email))
            .ReturnsAsync((BlogUser)null);

        _userManagerMock
            .SetupSequence(x => x.FindByNameAsync(request.UserName))
            .ReturnsAsync(new BlogUser());

        _userManagerMock
            .SetupSequence(x => x.GenerateEmailConfirmationTokenAsync(It.IsAny<BlogUser>()))
            .ReturnsAsync("token");

        _userManagerMock
            .Setup(x => x.CreateAsync(It.IsAny<BlogUser>(), request.Password))
            .ReturnsAsync(IdentityResult.Success);

        _userManagerMock
            .Setup(x => x.AddToRoleAsync(It.IsAny<BlogUser>(), "User"))
            .ReturnsAsync(IdentityResult.Success);

        // Act
        var result = await _authService.Register(request);

        Assert.NotNull(result);
        Assert.Equal(result.Success, true);
        Assert.NotNull(result.Value);

    }

    #endregion


    #region ResendConfirmEmailToken tests
    [Fact]
    public async Task sendConfirmEmailLink_ShouldReturnTrue_WhenUserFoundAndHasNotConfirmedEmail()
    {
        // Arrange
        var email = "user@example.com";
        var user = new BlogUser 
        { 
            Email = email, 
            UserName = email,
            EmailConfirmed = false
        };
        var expectedToken = "TOKEN123";

        var emailResult = new Result<Email>()
        {
            Success = true
        };

        _userManagerMock.Setup(u => u.FindByEmailAsync(email))
            .ReturnsAsync(user);
        _userManagerMock.Setup(u => u.GeneratePasswordResetTokenAsync(user))
            .ReturnsAsync(expectedToken);
        _emailSenderMock.Setup(u => u.sendEmail(It.IsAny<Email>()))
            .ReturnsAsync(emailResult);

        // Act
        var result = await _authService.sendConfirmEmailLink(email);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(result.Success, true);
        Assert.Equal(result.Value, email);
    }

    [Fact]
    public async Task sendConfirmEmailLink_ShouldReturnFalse_WhenUserNotFound()
    {
        // Arrange
        var email = "user@example.com";

        _userManagerMock.Setup(u => u.FindByEmailAsync(email))
            .ReturnsAsync((BlogUser)null);

        // Act
        var result = await _authService.sendConfirmEmailLink(email);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(result.Success, false);
        Assert.Equal(result.Value, null);
        
    }

    [Fact]
    public async Task sendConfirmEmailLink_ShouldReturnFalse_WhenEmailConfirmed()
    {
        // Arrange
        var email = "user@example.com";
        var user = new BlogUser 
        { 
            Email = email, 
            UserName = email,
            EmailConfirmed = true
        };

        _userManagerMock.Setup(u => u.FindByEmailAsync(email))
            .ReturnsAsync(user);

        // Act
        var result = await _authService.sendConfirmEmailLink(email);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(result.Success, false);
        Assert.Equal(result.Value, null);
        
    }

    #endregion


    #region  ForgotPassword tests
    [Fact]
    public async Task ForgotPassword_ShouldReturnTrue_WhenUserFoundAndHasConfirmedEmail()
    {
        // Arrange
        var email = "user@example.com";
        var user = new BlogUser 
        { 
            Email = email, 
            UserName = email,
            EmailConfirmed = true
        };
        var expectedToken = "TOKEN123";

        var emailResult = new Result<Email>()
        {
            Success = true
        };

        _userManagerMock.Setup(u => u.FindByEmailAsync(email))
            .ReturnsAsync(user);
        _userManagerMock.Setup(u => u.GeneratePasswordResetTokenAsync(user))
            .ReturnsAsync(expectedToken);
        _emailSenderMock.Setup(u => u.sendEmail(It.IsAny<Email>()))
            .ReturnsAsync(emailResult);

        // Act
        var result = await _authService.ForgotPassword(email);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(result.Success, true);
        Assert.Equal(result.Value, email);
    }

    [Fact]
    public async Task ForgotPassword_ShouldReturnFalse_WhenUserNotFound()
    {
        // Arrange
        var email = "user@example.com";

        _userManagerMock.Setup(u => u.FindByEmailAsync(email))
            .ReturnsAsync((BlogUser)null);

        // Act
        var result = await _authService.ForgotPassword(email);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(result.Success, false);
        Assert.Equal(result.Value, null);
        
    }

    public async Task ForgotPassword_ShouldReturnFalse_WhenEmailNotConfirmed()
    {
        // Arrange
        var email = "user@example.com";
        var user = new BlogUser 
        { 
            Email = email, 
            UserName = email,
            EmailConfirmed = false
        };

        _userManagerMock.Setup(u => u.FindByEmailAsync(email))
            .ReturnsAsync(user);

        // Act
        var result = await _authService.ForgotPassword(email);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(result.Success, false);
        Assert.Equal(result.Value, null);
        
    }

    #endregion


    #region  ResetPassword tests
    [Fact]
    public async Task ResetPassword_ShouldReturnTrue_WhenValidTokenAndNewPasswordProvided()
    {
        // Arrange
        var email = "user@example.com";
        var token = "TOKEN123";
        var newPassword = "newP@ssw0rd";
        var user = new BlogUser { Email = email, UserName = email };

        _userManagerMock.Setup(u => u.FindByEmailAsync(email))
            .ReturnsAsync(user);
        _userManagerMock.Setup(u => u.ResetPasswordAsync(user, token, newPassword))
            .ReturnsAsync(IdentityResult.Success);

        var resetModel = new ResetPasswordModel()
        {
            Email = email,
            Token = token,
            Password = newPassword
        };

        // Act
        var result = await _authService.ResetPassword(resetModel);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(result.Success, true);
        Assert.Equal(result.Value, email);
    }

    [Fact]
    public async Task ResetPassword_ShouldReturnFalse_WhenUserNotFound()
    {
        // Arrange
        var email = "user@example.com";
        var token = "TOKEN123";
        var newPassword = "newP@ssw0rd";

        _userManagerMock.Setup(u => u.FindByEmailAsync(email))
            .ReturnsAsync((BlogUser)null);

        var resetModel = new ResetPasswordModel()
        {
            Email = email,
            Token = token,
            Password = newPassword
        };

        // Act
        var result = await _authService.ResetPassword(resetModel);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(result.Success, false);
        Assert.Equal(result.Value, null);
    }

    [Fact]
    public async Task ResetPassword_ShouldReturnFalse_WhenInvalidTokenProvided()
    {
        // Arrange
        var email = "user@example.com";
        var user = new BlogUser { Email = email, UserName = email };
        var token = "TOKEN123";
        var newPassword = "newP@ssw0rd";

        var identityResult = IdentityResult.Failed(new IdentityError 
            { 
                Description = "Invalid Token." 
            });


        _userManagerMock.Setup(u => u.FindByEmailAsync(email))
            .ReturnsAsync(user);
        _userManagerMock.Setup(u => u.ResetPasswordAsync(user, token, newPassword))
            .ReturnsAsync(identityResult);

        var resetModel = new ResetPasswordModel()
        {
            Email = email,
            Token = token,
            Password = newPassword
        };

        // Act
        var result = await _authService.ResetPassword(resetModel);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(result.Success, false);
        Assert.Equal(result.Value, null);

    }

    #endregion

}

