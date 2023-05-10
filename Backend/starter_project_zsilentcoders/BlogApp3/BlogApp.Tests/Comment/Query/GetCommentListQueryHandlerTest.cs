using AutoMapper;
using BlogApp.Application.Contracts.Persistence;
using BlogApp.Application.Features.Comments.CQRS.Handlers;
using BlogApp.Application.Features.Comments.CQRS.Queries;
using BlogApp.Application.Profiles;
using BlogApp.Application.Tests.Mocks;
using Moq;
using Shouldly;
using Xunit;

namespace BlogApp.Tests.Comment.Query;

public class GetCommentListQueryHandlerTest
{

    private IMapper _mapper { get; set; }
    private Mock<IUnitOfWork> _mockUnitOfWork { get; set; }
    private GetCommentListQueryHandler _handler { get; set; }

    public GetCommentListQueryHandlerTest()
    {
        _mockUnitOfWork = MockUnitOfWork.GetUnitOfWork();

        _mapper = new MapperConfiguration(c =>
        {
            c.AddProfile<MappingProfile>();
        }).CreateMapper();

        _handler = new GetCommentListQueryHandler(_mockUnitOfWork.Object, _mapper);
    }

    [Fact]
    public async Task GetCommentListValid()
    {
        var result = await _handler.Handle(new GetCommentListQuery(), CancellationToken.None);
        result.ShouldNotBe(null);
    }

    [Fact]
    public async Task GetCommentListInvalid()
    {
        var result = await _handler.Handle(new GetCommentListQuery(), CancellationToken.None);
        result.Value.Count.ShouldNotBe(1);
    }
}
