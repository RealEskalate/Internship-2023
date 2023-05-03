using Application.Features.Blog.Handlers.Commands;
using BlogApp.Application.Contracts.Persistence;
using BlogApp.Application.Features.Blog.DTOs;
using BlogApp.Application.Features.Blog.CQRS.Requests.Commands;
using BlogApp.Application.Profiles;
using AutoMapper;
using Shouldly;
using Moq;
using BlogApp.Tests.Mocks;
using Xunit;

namespace BlogApp.Tests.Blog.Command;  

public class DeleteBlogCommandHandlerTest
{
       private IMapper _mapper { get; set; }
       private Mock<IBlogRepository> _mockRepo { get; set; }
       private DeleteBlogCommandHandler _handler { get; set; }
       

       public DeleteBlogCommandHandlerTest()
       { 
              _mockRepo = MockBlogRepository.GetBlogRepository();
              
              _mapper = new MapperConfiguration(c =>
              {
                     c.AddProfile<MappingProfile>();
              }).CreateMapper();

              _handler = new DeleteBlogCommandHandler(_mockRepo.Object, _mapper);
       }
       
       
       // [Fact]
       // public async Task DeleteBlogValid()
       // {
       //
       //        DeleteBlogDto deleteBlogDto = new() { Id = 1 };
       //        
       //        var result = await _handler.Handle(new DeleteBlogCommand() { DeleteBlogDto =  deleteBlogDto}, CancellationToken.None);
       //        
       //        (await _mockRepo.Object.GetAll()).Count.ShouldBe(1);
       // }
       //
       // [Fact]
       // public async Task DeleteBlogInvalid()
       // {
       //
       //        DeleteBlogDto deleteBlogDto = new() { Id = 100 };
       //        
       //        var result = await _handler.Handle(new DeleteBlogCommand() { DeleteBlogDto =  deleteBlogDto}, CancellationToken.None);
       //        
       //        (await _mockRepo.Object.GetAll()).Count.ShouldBe(2);
       // }
}


