using BlogApp.Application.Contracts.Persistence;
using BlogApp.Application.Features.Blog.DTOs;
using BlogApp.Application.Features.Blog.CQRS.Handlers.Commands;
using BlogApp.Application.Features.Blog.CQRS.Requests.Commands;
using BlogApp.Application.Profiles;
using AutoMapper;
using BlogApp.Tests.Mocks;
using Shouldly;
using Moq;
using Xunit;
using BlogApp.Tests.Mocks;
using BlogApp.Application.Features.Comments.DTOs;
using BlogApp.Application.Features.Comments.CQRS.Commands;
using BlogApp.Application.Features.Comments.CQRS.Handlers;

namespace BlogApp.Tests.Blog.Command;

public class UpdateCommentCommandHandlerTest
{
    private IMapper _mapper { get; set; }
    private Mock<IUnitOfWork> _mockUnitOfWork { get; set; }
    private UpdateCommentCommandHandler _handler { get; set; }


    public UpdateCommentCommandHandlerTest()
    {
        _mockUnitOfWork = MockUnitOfWork.GetUnitOfWork();

        _mapper = new MapperConfiguration(c =>
        {
            c.AddProfile<MappingProfile>();
        }).CreateMapper();

        _handler = new UpdateCommentCommandHandler(_mockUnitOfWork.Object, _mapper);
    }


    [Fact]
    public async Task UpdateCommentValid()
    {

        UpdateCommentDto commentDto = new()
        {
            Id=1,
            Content = "This is new comment",
            
                   };

        var result = await _handler.Handle(new UpdateCommentCommand() {CommentDto  = commentDto }, CancellationToken.None);

        var updatedComment = await _mockUnitOfWork.Object._CommentRepository.Get(1);

        updatedComment.Content.ShouldBe(commentDto.Content);
       

        (await _mockUnitOfWork.Object._CommentRepository.GetAll()).Count.ShouldBe(2);
    }
}
