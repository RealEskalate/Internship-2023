using AutoMapper;
using BlogApp.Application.Contracts.Persistence;
using BlogApp.Application.Features.Comments.CQRS.Handlers;
using BlogApp.Application.Features.Comments.CQRS.Queries;
using BlogApp.Application.Profiles;
using BlogApp.Tests.Mocks;
using Moq;
using Shouldly;
using Xunit;

namespace BlogApp.Tests.Comment.Query;

public class GetCommentDetailQueryHandlerTest
{

    
    private IMapper _mapper { get; set; }
    private Mock<IUnitOfWork> _mockUnitOfWork{ get; set; }  
    private GetCommentDetailQueryHandler _handler { get; set; }

    public GetCommentDetailQueryHandlerTest()
    { 
        _mockUnitOfWork = MockUnitOfWork.GetUnitOfWork();
              
        _mapper = new MapperConfiguration(c =>
        {
            c.AddProfile<MappingProfile>();
        }).CreateMapper();

        _handler = new GetCommentDetailQueryHandler(_mockUnitOfWork.Object, _mapper);
    }

    [Fact]
    public async Task GetBlogDetailsValid()
    {
        var result = await _handler.Handle(new GetCommentDetailQuery() { Id = 1}, CancellationToken.None);
        result.ShouldNotBe(null);
    }
       
    [Fact]
    public async Task GetBlogDetailsInvalid()
    {
        var result = await _handler.Handle(new GetCommentDetailQuery() { Id = 100}, CancellationToken.None);
        result.Value.ShouldBe(null);
    }
}




