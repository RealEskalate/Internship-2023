using System;
using System.Security.Claims;
using BlogApp.Application.Models.Identity;
using BlogApp.Identity.Repositories;
using BlogApp.Application.Contracts.Identity;
using BlogApp.Application.Features.Authentication.DTO;
using BlogApp.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Moq;
using Xunit;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http;

namespace BlogApp.Identity.UnitTests
{
    public class AuthServiceTests
    {
        private readonly AuthRepository _authRepository;
        private readonly Mock<UserManager<User>> _userManagerMock;
        private readonly Mock<SignInManager<User>> _signInManagerMock;

        public AuthServiceTests()
        {
            
            var mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<SignupFormDto, User>();
                cfg.CreateMap<User, SignUpResponse>();
            }).CreateMapper();
            var configuration = new ConfigurationBuilder()
            .AddJsonFile("/home/bahailu/Documents/a2sv/Internship-2023/Backend/starter_project_mavericks/BlogApp/BlogApp.API/appsettings.json", optional: true, reloadOnChange: true)
            .Build();

            _userManagerMock = new Mock<UserManager<User>>(Mock.Of<IUserStore<User>>(), null, null, null, null, null, null, null, null);
            _signInManagerMock = new Mock<SignInManager<User>>(_userManagerMock.Object, Mock.Of<IHttpContextAccessor>(), Mock.Of<IUserClaimsPrincipalFactory<User>>(), null, null, null, null);
            _authRepository = new AuthRepository(_userManagerMock.Object, _signInManagerMock.Object, mapper, configuration);
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
            await Assert.ThrowsAsync<Exception>(() => _authRepository.SignInAsync(signinFormDto));
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
            await Assert.ThrowsAsync<Exception>(() => _authRepository.SignInAsync(signinFormDto));
        }


        [Fact]
        public async Task Register_ShouldThrowException_WhenExistingUserFound()
        {
            // Arrange
            var request = new SignupFormDto
            {
                Email = "test@example.com",
                FirstName = "John",
                LastName = "Doe",
                Password = "P@ssw0rd",
            };

            _userManagerMock
                .Setup(x => x.FindByEmailAsync(request.Email))
                .ReturnsAsync(new User());

            // Act & Assert
            await Assert.ThrowsAsync<Exception>(() => _authRepository.SignUpAsync(request));
        }

        [Fact]
        public async Task Register_ShouldThrowException_WhenExistingEmailFound()
        {
            // Arrange
            var request = new SignupFormDto
            {
                Email = "test@example.com",
                FirstName = "John",
                LastName = "Doe",
                Password = "P@ssw0rd",
            };

            _userManagerMock
                .SetupSequence(x => x.FindByNameAsync(request.Email))
                .ReturnsAsync((User)null)
                .ReturnsAsync(new User());

            _userManagerMock
                .Setup(x => x.FindByEmailAsync(request.Email))
                .ReturnsAsync(new User());

            // Act & Assert
            await Assert.ThrowsAsync<Exception>(() => _authRepository.SignUpAsync(request));
        }

        [Fact]
        public async Task Register_ShouldReturnRegistrationResponse_WhenUserCreatedSuccessfully()
        {

            var signUpFormDto = new SignupFormDto
            {
                FirstName = "John",
                LastName = "Doe",
                Email = "john.doe@example.com",
                Password = "password"
            };

            _userManagerMock
                .Setup(x => x.FindByEmailAsync(signUpFormDto.Email))
                .ReturnsAsync((User)null);

            _userManagerMock
                .Setup(x => x.CreateAsync(It.IsAny<User>(), signUpFormDto.Password))
                .ReturnsAsync(IdentityResult.Success)
                .Callback<User, string>((user, password) =>
                {
                    user.Id = Guid.NewGuid().ToString();
                    user.UserName = signUpFormDto.Email;
                    user.Email = signUpFormDto.Email;
                });

            _userManagerMock
                .Setup(x => x.FindByNameAsync(signUpFormDto.Email))
                .ReturnsAsync(new User
                {
                    Id = Guid.NewGuid().ToString(),
                    FirstName = signUpFormDto.FirstName,
                    LastName = signUpFormDto.LastName,
                    Email = signUpFormDto.Email,
                    UserName = signUpFormDto.Email
                });

            var expectedResponse = new SignUpResponse
            {
                Id = "some_id",
                FirstName = "John",
                LastName = "Doe",
                Email = "john.doe@example.com"
            };

            var mapper = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, SignUpResponse>();
            }));

            // Act
            var response = await _authRepository.SignUpAsync(signUpFormDto);

            // Assert
            Assert.NotEqual(Guid.Empty.ToString(), response.Id);
            Assert.Equal(expectedResponse.FirstName, response.FirstName);
            Assert.Equal(expectedResponse.LastName, response.LastName);
            Assert.Equal(expectedResponse.Email, response.Email);

        }
    }

}