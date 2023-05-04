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

public class GetBlogDetailsQueryHandlerTest
{
    private IMapper _mapper { get; set; }
    private Mock<IUnitOfWork> _mockUnitOfWork{ get; set; }  
    private GetBlogDetailsQueryHandler _handler { get; set; }

    public GetBlogDetailsQueryHandlerTest()
    { 
        _mockUnitOfWork = MockUnitOfWork.GetUnitOfWork();
              
        _mapper = new MapperConfiguration(c =>
        {
            c.AddProfile<MappingProfile>();
        }).CreateMapper();

        _handler = new GetBlogDetailsQueryHandler(_mockUnitOfWork.Object, _mapper);
    }

    [Fact]
    public async Task GetBlogDetailsValid()
    {
        var result = await _handler.Handle(new GetBlogDetailsQuery() { Id = 1}, CancellationToken.None);
        result.ShouldNotBe(null);
    }
       
    [Fact]
    public async Task GetBlogDetailsInvalid()
    {
        var result = await _handler.Handle(new GetBlogDetailsQuery() { Id = 100}, CancellationToken.None);
        result.Value.ShouldBe(null);
    }
}


