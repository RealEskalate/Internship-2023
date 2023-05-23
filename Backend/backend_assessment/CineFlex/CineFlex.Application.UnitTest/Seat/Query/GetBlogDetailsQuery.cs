using CineFlex.Application.Contracts.Persistence;
using CineFlex.Application.Features.Seats.CQRS.Handlers.Queries;
using CineFlex.Application.Features.Seats.CQRS.Requests.Queries;
using CineFlex.Application.Profiles;
using AutoMapper;
using Shouldly;
using Moq;
using BlogApp.Tests.Mocks;
using CineFlex.Application.Contracts.Persistence;
using CineFlex.Application.Features.Seats.CQRS.Handlers.Queries;
using CineFlex.Application.Profiles;
using Xunit;

namespace BlogApp.Tests.Blog.Query;

public class GetBlogDetailsQueryHandlerTest
{
    private IMapper _mapper { get; set; }
    private Mock<IUnitOfWork> _mockUnitOfWork{ get; set; }  
    private GetSeatDetailQuerysHandler _handler { get; set; }

    public GetBlogDetailsQueryHandlerTest()
    { 
        _mockUnitOfWork = MockUnitOfWork.GetUnitOfWork();
              
        _mapper = new MapperConfiguration(c =>
        {
            c.AddProfile<MappingProfile>();
        }).CreateMapper();

        _handler = new GetSeatDetailQuerysHandler(_mockUnitOfWork.Object, _mapper);
    }

    [Fact]
    public async Task GetBlogDetailsValid()
    {
        var result = await _handler.Handle(new GetSeatDetailsQuery() { Id = 1}, CancellationToken.None);
        result.ShouldNotBe(null);
    }
       
    [Fact]
    public async Task GetBlogDetailsInvalid()
    {
        var result = await _handler.Handle(new GetSeatDetailsQuery() { Id = 100}, CancellationToken.None);
        result.Value.ShouldBe(null);
    }
}


