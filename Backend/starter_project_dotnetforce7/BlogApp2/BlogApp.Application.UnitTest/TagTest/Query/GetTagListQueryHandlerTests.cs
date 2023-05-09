using AutoMapper;
using BlogApp.Application.Contracts.Persistence;
using BlogApp.Application.Features.Tags.CQRS.Handlers;
using BlogApp.Application.Features.Tags.DTOs;
using Moq;
using BlogApp.Application.UnitTest.Mocks;
using BlogApp.Application.Profiles;
using BlogApp.Application.Features.Tags.CQRS.Queries;
using Shouldly;
using Xunit;
using BlogApp.Application.Responses;

namespace BlogApp.Application.UnitTest.TagTest.Query
{
    public class GetTagListQueryHandlerTests
    {

        private readonly IMapper _mapper;
        private readonly Mock<IUnitOfWork> _mockRepo;
        private readonly GetTagListQueryHandler _handler;


        public GetTagListQueryHandlerTests()
        {
            _mockRepo = MockUnitOfWork.GetUnitOfWork();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();

            _handler = new GetTagListQueryHandler(_mockRepo.Object, _mapper); 


        }


        [Fact]

        public async Task GetTagListTest()
        {

            var result = await _handler.Handle(new GetTagListQuery(), CancellationToken.None);

            result.ShouldBeOfType<Result<List<TagDto>>>();
            result.Success.ShouldBeTrue();
            result.Value.ShouldBeOfType<List<TagDto>>();

            result.Value.Count.ShouldBe(3);
        }


    }
}
