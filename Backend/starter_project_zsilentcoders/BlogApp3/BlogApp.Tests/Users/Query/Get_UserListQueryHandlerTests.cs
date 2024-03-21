using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BlogApp.Application.Contracts.Persistence;
using BlogApp.Application.Features.Users.CQRS.Handlers;
using BlogApp.Application.Features.Users.CQRS.Queries;
using BlogApp.Application.Features.Users.DTOs;
using BlogApp.Domain;
using Moq;
using Xunit;

namespace BlogApp.Tests.Users.Query
{
    public class Get_UserListQueryHandlerTests
    {
        private readonly Mock<IUnitOfWork> _mockUnitOfWork;
        private readonly Mock<IMapper> _mockMapper;

        public Get_UserListQueryHandlerTests()
        {
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _mockMapper = new Mock<IMapper>();
        }

        [Fact]
        public async Task Handle_ReturnsListOfUserDtos_WhenUsersExist()
        {
            // Arrange
            var users = new List<User>
            {
                new User { Id = 1, FirstName = "John", LastName = "Doe", Email = "johndoe@mail.com" },
                new User { Id = 2, FirstName = "Jane", LastName = "Doe", Email = "janedoe@mail.com" },
                new User { Id = 3, FirstName = "Bob", LastName = "Smith", Email = "bobsmith@mail.com" }
            };

            var userDtos = new List<_UserDto>
            {
                new _UserDto { Id = 1, FirstName = "John", LastName = "Doe", Email = "johndoe@mail.com" },
                new _UserDto { Id = 2, FirstName = "Jane", LastName = "Doe", Email = "janedoe@mail.com" },
                new _UserDto { Id = 3, FirstName = "Bob", LastName = "Smith", Email = "bobsmith@mail.com" }
            };

            _mockUnitOfWork.Setup(u => u._UserRepository.GetAll()).ReturnsAsync(users);
            _mockMapper.Setup(m => m.Map<List<_UserDto>>(users)).Returns(userDtos);

            var handler = new Get_UserListQueryHandler(_mockUnitOfWork.Object, _mockMapper.Object);

            // Act
            var result = await handler.Handle(new Get_UserListQuery(), CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<List<_UserDto>>(result);
            Assert.Equal(userDtos.Count, result.Count);

            for (int i = 0; i < userDtos.Count; i++)
            {
                Assert.Equal(userDtos[i].Id, result[i].Id);
                Assert.Equal(userDtos[i].FirstName, result[i].FirstName);
                Assert.Equal(userDtos[i].LastName, result[i].LastName);
                Assert.Equal(userDtos[i].Email, result[i].Email);
            }
        }

        [Fact]
        public async Task Handle_ReturnsEmptyList_WhenNoUsersExist()
        {
            // Arrange
            var users = new List<User>();
            var userDtos = new List<_UserDto>();

            _mockUnitOfWork.Setup(u => u._UserRepository.GetAll()).ReturnsAsync(users);
            _mockMapper.Setup(m => m.Map<List<_UserDto>>(users)).Returns(userDtos);

            var handler = new Get_UserListQueryHandler(_mockUnitOfWork.Object, _mockMapper.Object);

            // Act
            var result = await handler.Handle(new Get_UserListQuery(), CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<List<_UserDto>>(result);
            Assert.Empty(result);
        }
    }
}
