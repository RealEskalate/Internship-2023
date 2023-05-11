using AutoMapper;
using BlogApp.Application.Contracts.Persistence;
using BlogApp.Application.Features.Comments.CQRS.Commands;
using BlogApp.Application.Features.Comments.CQRS.Handlers;
using BlogApp.Application.Features.Comments.DTOs;
using BlogApp.Application.Profiles;
using BlogApp.Tests.Mocks;
using Moq;
using Shouldly;
using Xunit;

namespace BlogApp.Tests.Comment.Command;

public class CreateCommentCommandHandlerTest
{

    
       private IMapper _mapper { get; set; }
       private Mock<IUnitOfWork> _mockUnitOfWork { get; set; }
       private CreateCommentCommandHandler _handler { get; set; }
       

       public CreateCommentCommandHandlerTest()
       {
              _mockUnitOfWork = MockUnitOfWork.GetUnitOfWork();
              
              _mapper = new MapperConfiguration(c =>
              {
                     c.AddProfile<MappingProfile>();
              }).CreateMapper();

              _handler = new CreateCommentCommandHandler(_mockUnitOfWork.Object, _mapper);
       }
       
       
       [Fact]
       public async Task CreateCommentValid()
       {
       
              CreateCommentDto createCommentDto = new()
              {
                     CommenterId =  3,
                     Content =  "That is nice Blog",
                     BlogId = 1,
              };
              
              var result = await _handler.Handle(new CreateCommentCommand() {  CommentDto = createCommentDto }, CancellationToken.None);
              
              result.Value?.Content.ShouldBeEquivalentTo(createCommentDto.Content);
              result.Value?.CommenterId.ShouldBeEquivalentTo(createCommentDto.CommenterId);
              result.Value?.BlogId.ShouldBeEquivalentTo(createCommentDto.BlogId);
              
              (await _mockUnitOfWork.Object._CommentRepository.GetAll()).Count.ShouldBe(3);
       }
       
       [Fact]
       public async Task CreateCommentInvalid()
       {
       
              CreateCommentDto createBlogDto = new()
              {
                     CommenterId= 0,  
                     Content = "Body of the new blog",
                     BlogId = 1,
              };
              
              var result = await _handler.Handle(new CreateCommentCommand() { CommentDto = createBlogDto }, CancellationToken.None);
              
              result.Value.ShouldBe(null);
       }
}
