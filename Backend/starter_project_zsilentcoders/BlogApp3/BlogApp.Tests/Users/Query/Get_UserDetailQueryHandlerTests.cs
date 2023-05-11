using AutoMapper;
using BlogApp.Application.Contracts.Persistence;
using BlogApp.Application.Features.Users.CQRS.Handlers;
using BlogApp.Application.Features.Users.CQRS.Queries;
using BlogApp.Application.Features.Users.DTOs;
using BlogApp.Domain;
using Moq;
using System.Threading;
using Xunit;

namespace BlogApp.Tests.Users.Query
{
    public class Get_UserDetailQueryHandlerTests
    {
        private readonly Mock<IUnitOfWork> _mockUnitOfWork;
        private readonly Mock<IMapper> _mockMapper;

        public Get_UserDetailQueryHandlerTests()
        {
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _mockMapper = new Mock<IMapper>();
        }

        [Fact]
        public async void Handle_WithValidQuery_ShouldReturnUserDto()
        {
            // Arrange
            var userId = 1;
            var user = new User { Id = userId, FirstName = "John", LastName = "Doe", Email = "johndoe@example.com" };
            var expectedUserDto = new _UserDto { Id = userId, FirstName = "John", LastName = "Doe", Email = "johndoe@example.com" };
            var query = new Get_UserDetailQuery { Id = userId };
            var cancellationToken = new CancellationToken();

            _mockUnitOfWork.Setup(uow => uow._UserRepository.Get(userId)).ReturnsAsync(user);
            _mockMapper.Setup(m => m.Map<_UserDto>(user)).Returns(expectedUserDto);

            var handler = new Get_UserDetailQueryHandler(_mockUnitOfWork.Object, _mockMapper.Object);

            // Act
            var result = await handler.Handle(query, cancellationToken);

            // Assert
            Assert.Equal(expectedUserDto, result);
        }
    }
}
