using BlogApp.Application.Contracts.Persistence;
using BlogApp.Application.Features.Tags.CQRS.Handlers;
using BlogApp.Application.Features.Tags.CQRS.Queries;
using BlogApp.Application.Profiles;
using AutoMapper;
using BlogApp.Application.Tests.Mocks;
using Shouldly;
using Moq;
using BlogApp.Tests.Mocks;
using Xunit;

namespace BlogApp.Tests.Tags.Query;

public class GetTagListQueryHandlerTest
{
    private IMapper _mapper { get; set; }
    private Mock<IUnitOfWork> _mockUnitOfWork { get; set; }
    private GetTagListQueryHandler _handler { get; set; }

    public GetTagListQueryHandlerTest()
    {
        _mockUnitOfWork = MockUnitOfWork.GetUnitOfWork();

        _mapper = new MapperConfiguration(c =>
        {
            c.AddProfile<MappingProfile>();
        }).CreateMapper();

        _handler = new GetTagListQueryHandler(_mockUnitOfWork.Object, _mapper);
    }

    [Fact]
    public async Task GetTagListValid()
    {
        var result = await _handler.Handle(new GetTagListQuery(), CancellationToken.None);
        result.ShouldNotBe(null);
    }

    [Fact]
    public async Task GetTagListInvalid()
    {
        var result = await _handler.Handle(new GetTagListQuery(), CancellationToken.None);
        result.Value.Count.ShouldNotBe(1);
    }
}
