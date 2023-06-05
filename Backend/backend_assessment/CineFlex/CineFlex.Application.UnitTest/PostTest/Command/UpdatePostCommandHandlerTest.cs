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
using Xunit;

namespace CineFlex.Application.UnitTest.PostTest.Command
{
    public class UpdatePostCommandHandlerTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<IUnitOfWork> _mockRepo;
        private readonly UpdatePostDto _postDto;
        private readonly UpdatePostCommandHandler _handler;
        public UpdatePostCommandHandlerTest()
        {
            _mockRepo = MockUnitOfWork.GetUnitOfWork();
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });
            _mapper = mapperConfig.CreateMapper();

            _postDto = new UpdatePostDto
            {
                Title = "Title for post two",
				Content = "Content for post two",
				UserId = 2,
            };

            _handler = new UpdatePostCommandHandler(_mockRepo.Object, _mapper);

        }


        // [Fact]
        // public async Task UpdatePost()
        // {
        //     var result = await _handler.Handle(new UpdatePostCommand() { updatePostDto = _postDto }, CancellationToken.None);
        //     result.ShouldBeOfType<BaseCommandResponse<Unit>>();
        //     result.Success.ShouldBeTrue();

        //     var post = await _mockRepo.Object.PostRepository.Get(_postDto.Id);
        //     post.Id.Equals(_postDto.Id);
        //     post.Title.Equals(_postDto.Title);
        //     post.Content.Equals(_postDto.Content);
        //     post.UserId.Equals(_postDto.UserId);

        // }


        [Fact]
        public async Task Update_With_Invalid_PostContent()
        {

            _postDto.Content = "";
            var result = await _handler.Handle(new UpdatePostCommand() { updatePostDto = _postDto }, CancellationToken.None);
            result.ShouldBeOfType<BaseCommandResponse<Unit>>();
            result.Success.ShouldBeFalse();

            result.Errors.ShouldNotBeEmpty();
            var posts = await _mockRepo.Object.PostRepository.GetAll();
            posts.Count.ShouldBe(2);

        }

    }
}


