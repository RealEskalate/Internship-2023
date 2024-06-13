using AutoMapper;
using CineFlex.Application.Contracts.Persistence;
using CineFlex.Application.Features.Posts.CQRS.Handlers;
using CineFlex.Application.Features.Posts.CQRS.Queries;
using CineFlex.Application.Features.Posts.DTOs;
using CineFlex.Application.Profiles;
using CineFlex.Application.Responses;
using CineFlex.Application.UnitTest.Mocks;
using Moq;
using Shouldly;
using Xunit;

namespace CineFlex.Application.UnitTest.PostTest.Query
{
    public class GetPostListQueryHandlerTest
    {


        private readonly IMapper _mapper;
        private readonly Mock<IUnitOfWork> _mockRepo;
        private readonly GetPostListQueryHandler _handler;
        public GetPostListQueryHandlerTest()
        {
            _mockRepo = MockUnitOfWork.GetUnitOfWork();
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });
            _mapper = mapperConfig.CreateMapper();

            _handler = new GetPostListQueryHandler(_mockRepo.Object, _mapper);

        }


        [Fact]
        public async Task GetPostList()
        {
            var result = await _handler.Handle(new GetPostListQuery(), CancellationToken.None);
            result.ShouldBeOfType<BaseCommandResponse<List<PostDto>>>();
            result.Success.ShouldBeTrue();
            result.Value.ShouldBeOfType<List<PostDto>>(); 
            result.Value.Count.ShouldBe(2);
        }
    }
}


