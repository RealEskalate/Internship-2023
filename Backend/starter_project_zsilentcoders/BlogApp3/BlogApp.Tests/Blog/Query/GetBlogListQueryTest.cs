using BlogApp.Application.Contracts.Persistence;
using BlogApp.Application.Features.Blog.CQRS.Handlers.Queries;
using BlogApp.Application.Features.Blog.CQRS.Requests.Queries;
using BlogApp.Application.Profiles;
using AutoMapper;
using BlogApp.Application.Tests.Mocks;
using Shouldly;
using Moq;
using BlogApp.Tests.Mocks;
using Xunit;

namespace BlogApp.Tests.Blog.Query;

public class GetBlogListQueryHandlerTest
{
    private IMapper _mapper { get; set; }
    private Mock<IUnitOfWork> _mockUnitOfWork { get; set; }
    private GetBlogListQueryHandler _handler { get; set; }

    public GetBlogListQueryHandlerTest()
    {
        _mockUnitOfWork = MockUnitOfWork.GetUnitOfWork();

        _mapper = new MapperConfiguration(c =>
        {
            c.AddProfile<MappingProfile>();
        }).CreateMapper();

        _handler = new GetBlogListQueryHandler(_mockUnitOfWork.Object, _mapper);
    }

    [Fact]
    public async Task GetBlogListValid()
    {
        var result = await _handler.Handle(new GetBlogListQuery(), CancellationToken.None);
        result.ShouldNotBe(null);
    }

    [Fact]
    public async Task GetBlogListInvalid()
    {
        var result = await _handler.Handle(new GetBlogListQuery(), CancellationToken.None);
        result.Value.Count.ShouldNotBe(1);
    }
}
