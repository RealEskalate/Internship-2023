using AutoMapper;
using CineFlex.Application.Contracts.Persistence;
using CineFlex.Application.Features.Posts.CQRS.Commands;
using CineFlex.Application.Features.Posts.CQRS.Handlers;
using CineFlex.Application.Features.Posts.DTOs;
using CineFlex.Application.Profiles;
using CineFlex.Application.Responses;
using CineFlex.Application.UnitTest.Mocks;
using MediatR;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CineFlex.Application.UnitTest.Posts
{
    public class UpdatePostCommandHandlerTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<IUnitOfWork> _mockUow;
        private readonly UpdatePostCommandHandler _handler;
        public UpdatePostCommandHandlerTest()
        {
            _mockUow = MockUnitOfWork.GetUnitOfWork();
            var mapperConfig = new MapperConfiguration(c => { c.AddProfile<MappingProfile>(); });
            _mapper = mapperConfig.CreateMapper();
            _handler = new UpdatePostCommandHandler(_mockUow.Object, _mapper);
        }

        [Fact]
        public async Task validatePostUpdate()
        {
            var postUpdate = new UpdatePostDto
            {

                Title = "This is backend assessement first",
                Content = "It contain the description of assessment first"
            };
            var response = await _handler.Handle(new UpdatePostCommand()
            {
                UpdatePostDto = postUpdate
            }, CancellationToken.None);

            var post = await _mockUow.Object.PostRepository.Get(id: 1);
            response.ShouldNotBeNull();
            response.ShouldBeOfType<BaseCommandResponse<Unit>>();
            post.Title.ShouldBe(postUpdate.Title);
            post.Content.ShouldBe(postUpdate.Content);
            response.Success.ShouldBeTrue();
        }

        [Fact]
        public async Task InvalidPostUpdateWithInvalidIdTest()
        {
            var response = await _handler.Handle(new UpdatePostCommand()
            {
                UpdatePostDto = new UpdatePostDto()
                {
                    Id = 2000,
                    Title = "This is backend assessement second",
                    Content = "It contain the description of assessment second"
                }
            }, CancellationToken.None);

            response.ShouldNotBeNull();
            response.ShouldBeOfType<BaseCommandResponse<Unit>>();
            response.Success.ShouldBeFalse();
        }

        [Fact]
        public async Task InvalidPostUpdateWithNullTest()
        {
            var response = await _handler.Handle(new UpdatePostCommand()
            {
                UpdatePostDto = new UpdatePostDto()
                {
                    Id = 2,
                    Title = null,
                    Content = null
                }
            }, CancellationToken.None);

            response.ShouldNotBeNull();
            response.ShouldBeOfType<BaseCommandResponse<Unit>>();
            response.Success.ShouldBeFalse();
        }

        [Fact]
        public async Task InvalidReviewUpdateWithEmptyTittleTest()
        {
            var response = await _handler.Handle(new UpdatePostCommand()
            {
                UpdatePostDto = new UpdatePostDto()
                {
                    Id = 2,
                    Title = "",
                    Content = "It contain the description of assessment third"
                }
            }, CancellationToken.None);
        }
    }
}
