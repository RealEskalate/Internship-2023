using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CineFlex.Application.Contracts.Persistence;
using CineFlex.Application.Features.Posts.CQRS.Commands;
using CineFlex.Application.Features.Posts.CQRS.Handlers;
using CineFlex.Application.Features.Posts.DTOs;
using CineFlex.Application.Profiles;
using CineFlex.Application.Responses;
using CineFlex.Application.UnitTest.Mocks;
using Moq;
using Shouldly;
using Xunit;

namespace CineFlex.Application.UnitTest.Posts
{
    public class CreatePostCommandHandlerTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<IUnitOfWork> _mockUow;
        private readonly CreatePostCommandHandler _handler;

        public CreatePostCommandHandlerTest()
        {
            _mockUow = MockUnitOfWork.GetUnitOfWork();
            var mapperConfig = new MapperConfiguration(c => { c.AddProfile<MappingProfile>(); });
            _mapper = mapperConfig.CreateMapper();
            _handler = new CreatePostCommandHandler(_mockUow.Object, _mapper);

        }
        [Fact]
        public async Task ValidatePostCreationTest()
        {
            // arrange
            var request = new CreatePostCommand()
            {
                CreatePostDto = new CreatePostDto
                {
                    Title = "A2sv Tutorials",
                    Content = "hello",
                    UserId = 1
                }
            };


            // Act
            var response = await _handler.Handle(request, CancellationToken.None);
            // Assert
            response.ShouldNotBeNull();
            response.ShouldBeOfType<BaseCommandResponse<int>>();
            response.Success.ShouldBeTrue();
            response.Value.ShouldBe(4);



        }
        [Fact]
        public async Task InValidatePostCreationWithoutUserId()
        {

            //Arrange
            var request = new CreatePostCommand
            {
                CreatePostDto = new CreatePostDto
                {
                    Title = "Hello",
                    Content = "1234"
                }
            };

            //Act
            var response = await _handler.Handle(request, CancellationToken.None);
            response.ShouldNotBeNull();
            response.ShouldBeOfType<BaseCommandResponse<int>>();
            response.Success.ShouldBeFalse();

        }

        
        [Fact]
        public async Task InvalidatePostCreationWithoutTitle()
        {
            var request = new CreatePostCommand
            {
                CreatePostDto = new CreatePostDto
                {
                    Content = "hell",
                    UserId = 1
                }
            };

            var response = await _handler.Handle(request, CancellationToken.None);
            response.ShouldNotBeNull();
            response.ShouldBeOfType<BaseCommandResponse<int>>();
            response.Success.ShouldBeFalse();
        }

        [Fact]
        public async Task InvalidatePostCreationWithoutContent()
        {
            var request = new CreatePostCommand
            {
                CreatePostDto = new CreatePostDto
                {
                    Title = "hell",
                    UserId = 1
                }
            };

            var response = await _handler.Handle(request, CancellationToken.None);
            response.ShouldNotBeNull();
            response.ShouldBeOfType<BaseCommandResponse<int>>();
            response.Success.ShouldBeFalse();
        }

        [Fact]
        public async Task InvalidatePostCreationWithNullTitle()
        {
            var request = new CreatePostCommand
            {
                CreatePostDto = new CreatePostDto
                {
                    Title = null,
                    Content = "hell",
                    UserId = 1
                }
            };

            var response = await _handler.Handle(request, CancellationToken.None);
            response.ShouldNotBeNull();
            response.ShouldBeOfType<BaseCommandResponse<int>>();
            response.Success.ShouldBeFalse();
        }

        [Fact]
        public async Task InvalidatePostCreationWithNullContent()
        {
            var request = new CreatePostCommand
            {
                CreatePostDto = new CreatePostDto
                {
                    Title = "hell",
                    Content = null,
                    UserId = 1
                }
            };

            var response = await _handler.Handle(request, CancellationToken.None);
            response.ShouldNotBeNull();
            response.ShouldBeOfType<BaseCommandResponse<int>>();
            response.Success.ShouldBeFalse();
        }



    }
}