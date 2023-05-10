// using BlogApp.Application.Contracts.Identity;
// using BlogApp.Application.Exceptions;
// using BlogApp.Application.Features.Authentication.CQRS.Commands;
// using BlogApp.Application.Features.Authentication.CQRS.Handlers;
// using BlogApp.Application.Features.Authentication.DTO;
// using BlogApp.Application.Models.Identity;
// using BlogApp.Application.Responses;
// using BlogApp.Domain;
// using Microsoft.AspNetCore.Identity;
// using BlogApp.UnitTests.Mocks;
// using Moq;
// using System.Collections.Generic;
// using System.Security.Claims;
// using System.Threading.Tasks;
// using Xunit;

// namespace BlogApp.UnitTests
// {
//     public class SigninHandlerTests
//     {
//         private readonly MockAuthRepository _authRepository;
//         private readonly Mock<IUserStore<User>> _userStoreMock;
//         private readonly Mock<UserManager<User>> _userManagerMock;
//         private readonly Mock<SignInManager<User>> _signInManagerMock;

//         public SigninHandlerTests()
//         {
//             _userStoreMock = new Mock<IUserStore<User>>();
//             _userManagerMock = new Mock<UserManager<User>>(_userStoreMock.Object, null, null, null, null, null, null, null, null);
//             _signInManagerMock = new Mock<SignInManager<User>>(_userManagerMock.Object, null, null, null, null, null, null);
//             _authRepository = new MockAuthRepository();
//         }

//         [Fact]
//         public async Task Handle_ShouldReturnAuthResponse_WhenValidCredentialsProvided()
//         {
//             // Arrange
//             var email = "test1@example.com";
//             var password = "Pa$$w0rd";
//             var user = new User { Email = email, UserName = email, FirstName = "John", LastName = "Doe", PasswordHash = password };
//             var signinFormDto = new SigninFormDto { Email = email, Password = password };

//             _userManagerMock.Setup(u => u.FindByEmailAsync(email))
//                 .ReturnsAsync(user);
//             _userManagerMock.Setup(u => u.GetClaimsAsync(user))
//                 .ReturnsAsync(new List<Claim>());
//             _userManagerMock.Setup(u => u.GetRolesAsync(user))
//                 .ReturnsAsync(new List<string>());
//             _signInManagerMock.Setup(s => s.CheckPasswordSignInAsync(user, password, false))
//                 .ReturnsAsync(Microsoft.AspNetCore.Identity.SignInResult.Success);

//             var handler = new SigninHandler(_authRepository);

//             // Act
//             var result = await handler.Handle(new SigninCommand { SigninFormDto = signinFormDto }, default);

//             // Assert
//             Assert.NotNull(result);
//             Assert.Equal(user.FirstName, result.Data.FirstName);
//             Assert.Equal(user.LastName, result.Data.LastName);
//             Assert.Equal(user.Email, result.Data.Email);
//             Assert.Equal("mock-token", result.Data.Token);
//         }

//         [Fact]
//         public async Task Handle_ShouldThrowException_WhenUserNotFound()
//         {
//             // Arrange
//             var email = "user@example.com";
//             var password = "Pa$$w0rd";
//             var signinFormDto = new SigninFormDto { Email = email, Password = password };

//             _userManagerMock.Setup(u => u.FindByEmailAsync(email))
//                 .ReturnsAsync((User)null);

//             var handler = new SigninHandler(_authRepository);

//             // Act & Assert
//             await Assert.ThrowsAsync<NotFoundException>(() => handler.Handle(new SigninCommand { SigninFormDto = signinFormDto }, default));
//         }

//         [Fact]
//         public async Task Handle_ShouldThrowException_WhenInvalidCredentialsProvided()
//         {
//             // Arrange
//             var email = "test1@example.com";
//             var password = "Pa$$w0rd";
//             var user = new User { Email = email, UserName = email, PasswordHash = "invalid-password" };
//             var signinFormDto = new SigninFormDto { Email = email, Password = password };

//             _userManagerMock.Setup(u => u.FindByEmailAsync(email))
//                 .ReturnsAsync(user);
//             _signInManagerMock.Setup(s => s.CheckPasswordSignInAsync(user, password, false))
//                 .ReturnsAsync(Microsoft.AspNetCore.Identity.SignInResult.Failed);

//             var handler = new SigninHandler(_authRepository);

//             // Act & Assert
//             await Assert.ThrowsAsync<BadRequestException>(() => handler.Handle(new SigninCommand { SigninFormDto = signinFormDto }, default));
//         }
//     }

using BlogApp.Application.Features.Authentication.DTO;
using BlogApp.Application.Models.Identity;
using BlogApp.Application.Exceptions;
using BlogApp.Identity.Repositories;
using BlogApp.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Xunit;
using BlogApp.Persistence;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.Identity.UnitTests
{
    public class SignInHandlerTests
    {
        private readonly AuthRepository _authRepository;
        private readonly Mock<UserManager<User>> _userManagerMock;
        private readonly Mock<SignInManager<User>> _signInManagerMock;

        public SignInHandlerTests()
        {
            var services = new ServiceCollection();
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("/home/bahailu/Documents/a2sv/Internship-2023/Backend/starter_project_mavericks/BlogApp/BlogApp.API/appsettings.json", optional: true, reloadOnChange: true)
                .Build();

            services.AddDbContext<UserIdentityDbContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("BlogAppConnectionString"));
            });

            _userManagerMock = new Mock<UserManager<User>>(Mock.Of<IUserStore<User>>(), null, null, null, null, null, null, null, null);
            _signInManagerMock = new Mock<SignInManager<User>>(_userManagerMock.Object, Mock.Of<IHttpContextAccessor>(), Mock.Of<IUserClaimsPrincipalFactory<User>>(), null, null, null, null);

            _authRepository = new AuthRepository(_userManagerMock.Object, _signInManagerMock.Object, null, configuration, null);
        }

        [Fact]
        public async Task Login_ShouldReturnAuthResponse_WhenValidCredentialsProvided()
        {
            // Arrange
            var email = "user@example.com";
            var password = "Pa$$w0rd";
            var user = new User { Email = email, UserName = email };
            var signinFormDto = new SigninFormDto { Email = email, Password = password };

            _userManagerMock.Setup(u => u.FindByEmailAsync(email))
                .ReturnsAsync(user);
            _userManagerMock.Setup(u => u.GetClaimsAsync(user))
                .ReturnsAsync(new List<Claim>());
            _userManagerMock.Setup(u => u.GetRolesAsync(user))
                .ReturnsAsync(new List<string>());
            _signInManagerMock.Setup(s => s.CheckPasswordSignInAsync(user, password, false))
                .ReturnsAsync(SignInResult.Success);

            // Act
            var result = await _authRepository.SignInAsync(signinFormDto);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(user.Id, result.Id);
            Assert.Equal(user.Email, result.Email);
            Assert.Equal(user.UserName, result.Email);
        }

        [Fact]
        public async Task Login_ShouldThrowException_WhenUserNotFound()
        {
            // Arrange
            var email = "user@example.com";
            var password = "Pa$$w0rd";
            var signinFormDto = new SigninFormDto { Email = email, Password = password };

            _userManagerMock.Setup(u => u.FindByEmailAsync(email))
                .ReturnsAsync((User)null);

            // Act & Assert
            await Assert.ThrowsAsync<BadRequestException>(() => _authRepository.SignInAsync(signinFormDto));
        }

        [Fact]
        public async Task Login_ShouldThrowException_WhenInvalidCredentialsProvided()
        {
            // Arrange
            var email = "user@example.com";
            var password = "Pa$$w0rd";
            var user = new User { Email = email, UserName = email };
            var signinFormDto = new SigninFormDto { Email = email, Password = password };

            _userManagerMock.Setup(u => u.FindByEmailAsync(email))
                .ReturnsAsync(user);
            _signInManagerMock.Setup(s => s.CheckPasswordSignInAsync(user, password, false))
                .ReturnsAsync(SignInResult.Failed);

            // Act & Assert
            await Assert.ThrowsAsync<BadRequestException>(() => _authRepository.SignInAsync(signinFormDto));
        }
    }
}