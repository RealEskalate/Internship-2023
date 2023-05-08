using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using BlogApp.Application.Models.Identity;
using BlogApp.Identity.Models;
using BlogApp.Identity.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Moq;
Ø
namespace BlogApp.Identity.UnitTests
{
    public class AuthServiceTests
    {
        private readonly AuthService _authService;
        private readonly Mock<UserManager<ApplicationUser>> _userManagerMock;
        private readonly Mock<SignInManager<ApplicationUser>> _signInManagerMock;

        public AuthServiceTests()
        {
            _userManagerMock = new Mock<UserManager<ApplicationUser>>(Mock.Of<IUserStore<ApplicationUser>>(), null, null, null, null, null, null, null, null);
            _signInManagerMock = new Mock<SignInManager<ApplicationUser>>(_userManagerMock.Object, Mock.Of<IHttpContextAccessor>(), Mock.Of<IUserClaimsPrincipalFactory<ApplicationUser>>(), null, null, null, null);

            _authService = new AuthService(_userManagerMock.Object, Options.Create(new JwtSettings() { Key = "superdupersecretkey" }), _signInManagerMock.Object);
        }

        [Fact]
        public async Task Login_ShouldReturnAuthResponse_WhenValidCredentialsProvided()
        {
            // Arrange
            var email = "user@example.com";
            var password = "Pa$$w0rd";
            var user = new ApplicationUser { Email = email, UserName = email };
            var authRequest = new AuthRequest { Email = email, Password = password };

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
            Assert.Equal(user.Id, result.Id);
            Assert.Equal(user.Email, result.Email);
            Assert.Equal(user.UserName, result.Username);
        }

        [Fact]
        public async Task Login_ShouldThrowException_WhenUserNotFound()
        {
            // Arrange
            var email = "user@example.com";
            var password = "Pa$$w0rd";
            var authRequest = new AuthRequest { Email = email, Password = password };

            _userManagerMock.Setup(u => u.FindByEmailAsync(email))
                .ReturnsAsync((ApplicationUser)null);

            // Act & Assert
            await Assert.ThrowsAsync<Exception>(() => _authService.Login(authRequest));
        }

        [Fact]
        public async Task Login_ShouldThrowException_WhenInvalidCredentialsProvided()
        {
            // Arrange
            var email = "user@example.com";
            var password = "Pa$$w0rd";
            var user = new ApplicationUser { Email = email, UserName = email };
            var authRequest = new AuthRequest { Email = email, Password = password };

            _userManagerMock.Setup(u => u.FindByEmailAsync(email))
                .ReturnsAsync(user);
            _signInManagerMock.Setup(s => s.PasswordSignInAsync(user.UserName, password, false, false))
                .ReturnsAsync(SignInResult.Failed);

            // Act & Assert
            await Assert.ThrowsAsync<Exception>(() => _authService.Login(authRequest));
        }


        [Fact]
        public async Task Register_ShouldThrowException_WhenExistingUserFound()
        {
            // Arrange
            var request = new RegistrationRequest
            {
                Email = "test@example.com",
                Firstname = "John",
                Lastname = "Doe",
                Password = "P@ssw0rd",
                Username = "johndoe"
            };

            _userManagerMock
                .Setup(x => x.FindByNameAsync(request.Username))
                .ReturnsAsync(new ApplicationUser());

            // Act & Assert
            await Assert.ThrowsAsync<Exception>(() => _authService.Register(request));
        }

        [Fact]
        public async Task Register_ShouldThrowException_WhenExistingEmailFound()
        {
            // Arrange
            var request = new RegistrationRequest
            {
                Email = "test@example.com",
                Firstname = "John",
                Lastname = "Doe",
                Password = "P@ssw0rd",
                Username = "johndoe"
            };

            _userManagerMock
                .SetupSequence(x => x.FindByNameAsync(request.Username))
                .ReturnsAsync((ApplicationUser)null)
                .ReturnsAsync(new ApplicationUser());

            _userManagerMock
                .Setup(x => x.FindByEmailAsync(request.Email))
                .ReturnsAsync(new ApplicationUser());

            // Act & Assert
            await Assert.ThrowsAsync<Exception>(() => _authService.Register(request));
        }

        [Fact]
        public async Task Register_ShouldReturnRegistrationResponse_WhenUserCreatedSuccessfully()
        {
            // Arrange
            var request = new RegistrationRequest
            {
                Email = "test@example.com",
                Firstname = "John",
                Lastname = "Doe",
                Password = "P@ssw0rd",
                Username = "johndoe"
            };

            _userManagerMock
                .SetupSequence(x => x.FindByNameAsync(request.Username))
                .ReturnsAsync((ApplicationUser)null)
                .ReturnsAsync((ApplicationUser)null);

            _userManagerMock
                .Setup(x => x.FindByEmailAsync(request.Email))
                .ReturnsAsync((ApplicationUser)null);

            _userManagerMock
                .Setup(x => x.CreateAsync(It.IsAny<ApplicationUser>(), request.Password))
                .ReturnsAsync(IdentityResult.Success);

            _userManagerMock
                .Setup(x => x.AddToRoleAsync(It.IsAny<ApplicationUser>(), "User"))
                .ReturnsAsync(IdentityResult.Success);

            // Act
            var response = await _authService.Register(request);

            // Assert
            Assert.NotNull(response);
            Assert.NotEqual(Guid.Empty.ToString(), response.UserId);
        }


    }

}