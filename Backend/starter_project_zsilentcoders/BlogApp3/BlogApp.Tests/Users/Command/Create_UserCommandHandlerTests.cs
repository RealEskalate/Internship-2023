using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BlogApp.Application.Contracts.Persistence;
using BlogApp.Application.Features.Users.CQRS.Commands;
using BlogApp.Application.Features.Users.CQRS.Handlers;
using BlogApp.Application.Features.Users.DTOs;
using BlogApp.Application.Features.Users.DTOs.Validators;
using BlogApp.Application.Responses;
using BlogApp.Application.Profiles;
using BlogApp.Tests.Mocks;
using BlogApp.Domain;
using FluentAssertions;
using Moq;
using Shouldly;
using Xunit;

namespace BlogApp.Tests.Users.Command
{
     public class Create_UserCommandHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IUnitOfWork> _mockUow;
        private readonly Create_UserDto _userDto;
        private readonly Create_UserDto _invalidUserDto;
        private readonly Create_UserCommandHandler _handler;

        public Create_UserCommandHandlerTests()
        {
            _mockUow = MockUnitOfWork.GetUnitOfWork();
            
            var mapperConfig = new MapperConfiguration(c => 
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
            _handler = new Create_UserCommandHandler(_mockUow.Object, _mapper);

            _userDto = new Create_UserDto
            {
                AccountId = "1",
                FirstName = "John",
                LastName = "Doe",
                Email = "johndoe@example.com",
                Password = "password"
            };

            _invalidUserDto = new Create_UserDto
            {
                AccountId = "2",
                FirstName = "",
                LastName = "Doe",
                Email = "johndoe@example.com",
                Password = "password"
            };
        }

        [Fact]
        public async Task Valid_User_Added()
        {
            var result = await _handler.Handle(new Create_UserCommand() { Create_UserDto = _userDto }, CancellationToken.None);

            var users = await _mockUow.Object._UserRepository.GetAll();

            result.ShouldBeOfType<BaseCommandResponse>();

            users.Count.ShouldBe(3);
        }

        [Fact]
        public async Task InValid_User_Added()
        {

            var result = await _handler.Handle(new Create_UserCommand() { Create_UserDto = _invalidUserDto}, CancellationToken.None);

            var users = await _mockUow.Object._UserRepository.GetAll();
            
            users.Count.ShouldBe(2);

            result.ShouldBeOfType<BaseCommandResponse>();
            
        }
    }
}
