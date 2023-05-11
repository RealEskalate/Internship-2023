using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BlogApp.Application.Contracts.Persistence;
using BlogApp.Application.Exceptions;
using BlogApp.Application.Features.Users.CQRS.Commands;
using BlogApp.Application.Features.Users.DTOs.Validators;
using BlogApp.Application.Features.Users.DTOs;
using BlogApp.Application.Features.Users.CQRS.Handlers;
using BlogApp.Domain;
using FluentAssertions;
using MediatR;
using Moq;
using Xunit;


namespace BlogApp.Tests.Users.Command
{
    public class Update_UserCommandHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IUnitOfWork> _mockUnitOfWork;
        private readonly Update_UserCommandHandler _handler;

        public Update_UserCommandHandlerTests()
        {
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Update_UserDto, User>();
            });

            _mapper = mapperConfig.CreateMapper();
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _handler = new Update_UserCommandHandler(_mockUnitOfWork.Object, _mapper);
        }

        [Fact]
        public async Task UpdateUserCommandHandler_WhenUserExists_ShouldUpdateUser()
        {
            // Arrange
            var existingUserId = 1;
            var existingUser = new User
            {
                Id = existingUserId,
                FirstName = "John",
                LastName = "Doe",
                Email = "johndoe@example.com",
                Password = "password"
            };
            var updateDto = new Update_UserDto
            {
                Id = existingUserId,
                FirstName = "Jane",
                LastName = "Doe",
                Email = "janedoe@example.com",
                Password = "newpassword"
            };
             var command = new Update_UserCommand()
                        {
                        Update_UserDto = updateDto
                        };
            _mockUnitOfWork.Setup(uow => uow._UserRepository.Get(existingUserId))
                .ReturnsAsync(existingUser);

            // Act
            await _handler.Handle(command, CancellationToken.None);

            // Assert
            _mockUnitOfWork.Verify(uow => uow._UserRepository.Update(It.IsAny<User>()), Times.Once);
            _mockUnitOfWork.Verify(uow => uow.Save(), Times.Once);
            existingUser.FirstName.Should().Be(updateDto.FirstName);
            existingUser.LastName.Should().Be(updateDto.LastName);
            existingUser.Email.Should().Be(updateDto.Email);
            existingUser.Password.Should().Be(updateDto.Password);
        }

        [Fact]
        public async Task UpdateUserCommandHandler_WhenUserDoesNotExist_ShouldThrowNotFoundException()
        {
            // Arrange
            var nonExistingUserId = 1;
            var updateDto = new Update_UserDto
            {
                Id = nonExistingUserId,
                FirstName = "Jane",
                LastName = "Doe",
                Email = "janedoe@example.com",
                Password = "newpassword"
            };
          var command = new Update_UserCommand()
                        {
                            Update_UserDto = updateDto
                        };
            _mockUnitOfWork.Setup(uow => uow._UserRepository.Get(nonExistingUserId))
                .ReturnsAsync(() => null);

            // Act & Assert
            await Assert.ThrowsAsync<NotFoundException>(() => _handler.Handle(command, CancellationToken.None));
        }
    }
}

