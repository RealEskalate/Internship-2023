using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BlogApp.Application.Contracts.Identity;
using BlogApp.Domain.Models.Identity;
using BlogApp.Identity.Models;
using BlogApp.Identity.Services;
using Microsoft.AspNetCore.Identity;
using Moq;
using Xunit;

namespace BlogApp.Identity.UnitTests
{
    public class UserServiceTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<UserManager<ApplicationUser>> _userManagerMock;

        public UserServiceTests()
        {
            // Create a mock IMapper and configure any necessary mappings
            var mapperConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<ApplicationUser, User>();
            });
            _mapper = mapperConfig.CreateMapper();

            // Create a mock UserManager<ApplicationUser> and set up any necessary methods
            _userManagerMock = new Mock<UserManager<ApplicationUser>>(new Mock<IUserStore<ApplicationUser>>().Object,
                                                                       null, null, null, null, null, null, null, null);
        }

        [Fact]
        public async Task GetUser_Returns_User()
        {
            // Arrange
            var userService = new UserService(_userManagerMock.Object);
            var userId = "123";

            var user = new ApplicationUser
            {
                Id = userId,
                Email = "test@example.com",
                Firstname = "John",
                Lastname = "Doe"
            };

            _userManagerMock.Setup(u => u.FindByIdAsync(userId))
                             .ReturnsAsync(user);

            // Act
            var result = await userService.GetUser(userId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(userId, result.Id);
            Assert.Equal(user.Email, result.Email);
            Assert.Equal(user.Firstname, result.Firstname);
            Assert.Equal(user.Lastname, result.Lastname);
        }

        [Fact]
        public async Task GetUsers_Returns_List_Of_Users()
        {
            // Arrange
            var userService = new UserService(_userManagerMock.Object);

            var users = new List<ApplicationUser>
            {
                new ApplicationUser
                {
                    Id = "123",
                    Email = "test1@example.com",
                    Firstname = "John",
                    Lastname = "Doe"
                },
                new ApplicationUser
                {
                    Id = "456",
                    Email = "test2@example.com",
                    Firstname = "Jane",
                    Lastname = "Doe"
                }
            };

            _userManagerMock.Setup(u => u.GetUsersInRoleAsync("User"))
                             .ReturnsAsync(users);

            // Act
            var result = await userService.GetUsers();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(users.Count, result.Count);
            Assert.Equal(users[0].Id, result[0].Id);
            Assert.Equal(users[0].Email, result[0].Email);
            Assert.Equal(users[0].Firstname, result[0].Firstname);
            Assert.Equal(users[0].Lastname, result[0].Lastname);
            Assert.Equal(users[1].Id, result[1].Id);
            Assert.Equal(users[1].Email, result[1].Email);
            Assert.Equal(users[1].Firstname, result[1].Firstname);
            Assert.Equal(users[1].Lastname, result[1].Lastname);
        }

        [Fact]
        public async Task GetUser_Returns_Null_When_User_Doesnt_Exist()
        {
            // Arrange
            var userService = new UserService(_userManagerMock.Object);
            var userId = "123";

            _userManagerMock.Setup(u => u.FindByIdAsync(userId))
                             .ReturnsAsync((ApplicationUser)null);

            // Act
            var result = await userService.GetUser(userId);

            // Assert
            Assert.Null(result);
        }
    }
}
