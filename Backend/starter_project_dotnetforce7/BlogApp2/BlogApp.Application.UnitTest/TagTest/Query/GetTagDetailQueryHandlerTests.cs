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
using BlogApp.Application.Features.Rates.DTOs;
using BlogApp.Application.Responses;

namespace BlogApp.Application.UnitTest.TagTest.Query
{
    public class GetTagDetailQueryHandlerTests
    {

        private readonly IMapper _mapper;
        private readonly Mock<IUnitOfWork> _mockRepo;
        private readonly GetTagDetailQueryHandler _handler;

        public GetTagDetailQueryHandlerTests()
        {
            _mockRepo = MockUnitOfWork.GetUnitOfWork();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
            _handler = new GetTagDetailQueryHandler(_mockRepo.Object, _mapper);

        }


        [Fact]

        public async Task GetTagDetailTest()
        {
            var result = await _handler.Handle(new GetTagDetailQuery { Id = 1 }, CancellationToken.None);

            result.ShouldBeOfType<Result<TagDto>>();
            result.Success.ShouldBeTrue();
            result.Value.ShouldBeOfType<TagDto>();
        }


        [Fact]
        public async Task GetNonExistingTagTest()
        {
            var result = await _handler.Handle(new GetTagDetailQuery{ Id = 0 }, CancellationToken.None);

            result.ShouldBeOfType<Result<TagDto>>();
            result.Success.ShouldBeTrue();
            result.Value.ShouldBe(null);

        }


    }
}
