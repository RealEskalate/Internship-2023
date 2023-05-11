using Application.Features.Blog.Handlers.Commands;
using BlogApp.Application.Contracts.Persistence;
using BlogApp.Application.Features.Blog.DTOs;
using BlogApp.Application.Features.Blog.CQRS.Requests.Commands;
using BlogApp.Application.Profiles;
using AutoMapper;
using BlogApp.Tests.Mocks;
using Shouldly;
using Moq;
using BlogApp.Tests.Mocks;
using Xunit;
using BlogApp.Application.Features.Comments.CQRS.Handlers;
using BlogApp.Application.Features.Comments.CQRS.Commands;
using BlogApp.Application.Features.Comments.DTOs;



namespace BlogApp.Tests.Blog.Command;  

public class DeleteCommentCommandHandlerTest
{
       private IMapper _mapper { get; set; }
       private Mock<IUnitOfWork> _mockUnitOfWork { get; set; }
       private DeleteCommentCommandHandler _handler { get; set; }

       public DeleteCommentCommandHandlerTest()
       {
              _mockUnitOfWork = MockUnitOfWork.GetUnitOfWork();
              
              _mapper = new MapperConfiguration(c =>
              {
                     c.AddProfile<MappingProfile>();
              }).CreateMapper();

              _handler = new DeleteCommentCommandHandler(_mockUnitOfWork.Object, _mapper);
       }
       
       
       [Fact]
       public async Task DeleteCommentValid()
       {
       
              DeleteCommentDto deleteCommentDto = new() { Id = 1};
              
               var result = await _handler.Handle(new DeleteCommentCommand() {  CommentDto =  deleteCommentDto}, CancellationToken.None);
               
              
              (await _mockUnitOfWork.Object._CommentRepository.GetAll()).Count.ShouldBe(1);
       }
       
       [Fact]
       public async Task DeleteCommentInvalid()
       {
                
               DeleteCommentDto deleteCommentDto = new() { Id = 2 };
              
              var result = await _handler.Handle(new DeleteCommentCommand() { CommentDto =  deleteCommentDto}, CancellationToken.None);
              
              (await _mockUnitOfWork.Object._CommentRepository.GetAll()).Count.ShouldBe(1);
       }
}


