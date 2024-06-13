using AutoMapper;
using CineFlex.Application.Contracts.Persistence;
using CineFlex.Application.Features.Posts.CQRS.Handlers;
using CineFlex.Application.Features.Posts.CQRS.Commands;
using CineFlex.Application.Features.Posts.DTOs;
using CineFlex.Application.Profiles;
using CineFlex.Application.Responses;
using CineFlex.Application.UnitTest.Mocks;
using MediatR;
using Moq;
using Shouldly;
using Xunit;

namespace CineFlex.Application.UnitTest.Posttest.Command
{
    public class DeletePostCommandHandlerTest
    {

        private readonly IMapper _mapper;
        private readonly Mock<IUnitOfWork> _mockRepo;
        private int _id { get; set; }
        private readonly DeletePostCommandHandler _handler;
        private readonly CreatePostDto _postDto;
        public DeletePostCommandHandlerTest()
        {
            _mockRepo = MockUnitOfWork.GetUnitOfWork();
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });
            _mapper = mapperConfig.CreateMapper();
            _postDto = new CreatePostDto
            {
                Title = "Title for post two",
				Content = "Content for post two",
				UserId = 2,
            };
            _id = 1;

            _handler = new DeletePostCommandHandler(_mockRepo.Object, _mapper);

        }


        [Fact]
        public async Task DeletePost()
        {

            var result = await _handler.Handle(new DeletePostCommand() { Id = _id }, CancellationToken.None);
            result.ShouldBeOfType<BaseCommandResponse<Unit>>();
            result.Success.ShouldBeTrue();

            var posts = await _mockRepo.Object.PostRepository.GetAll();
            posts.Count().ShouldBe(1);
        }

        [Fact]
        public async Task Delete_Post_Doesnt_Exist()
        {

            _id  = 0;
            var result = await _handler.Handle(new DeletePostCommand() { Id = _id }, CancellationToken.None);
            result.ShouldBe(null);
        
            var posts = await _mockRepo.Object.PostRepository.GetAll();
            posts.Count.ShouldBe(2);

        }
    }
}



