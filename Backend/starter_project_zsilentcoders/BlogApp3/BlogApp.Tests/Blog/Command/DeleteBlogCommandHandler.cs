using Application.Features.Blog.Handlers.Commands;
using BlogApp.Application.Contracts.Persistence;
using BlogApp.Application.Features.Blog.DTOs;
using BlogApp.Application.Features.Blog.CQRS.Requests.Commands;
using BlogApp.Application.Profiles;
using AutoMapper;
using BlogApp.Application.Tests.Mocks;
using Shouldly;
using Moq;
using BlogApp.Tests.Mocks;
using Xunit;

namespace BlogApp.Tests.Blog.Command;  

public class DeleteBlogCommandHandlerTest
{
       private IMapper _mapper { get; set; }
       private Mock<IUnitOfWork> _mockUnitOfWork { get; set; }
       private DeleteBlogCommandHandler _handler { get; set; }

       public DeleteBlogCommandHandlerTest()
       {
              _mockUnitOfWork = MockUnitOfWork.GetUnitOfWork();
              
              _mapper = new MapperConfiguration(c =>
              {
                     c.AddProfile<MappingProfile>();
              }).CreateMapper();

              _handler = new DeleteBlogCommandHandler(_mockUnitOfWork.Object, _mapper);
       }
 
       [Fact]
       public async Task DeleteBlogValid()
       {
       
              DeleteBlogDto deleteBlogDto = new() { Id = 1 };
              
              var result = await _handler.Handle(new DeleteBlogCommand() { DeleteBlogDto =  deleteBlogDto}, CancellationToken.None);
              
              (await _mockUnitOfWork.Object.BlogRepository.GetAll()).Count.ShouldBe(1);
       }
       
       [Fact]
       public async Task DeleteBlogInvalid()
       {
       
              DeleteBlogDto deleteBlogDto = new() { Id = 100 };
              
              var result = await _handler.Handle(new DeleteBlogCommand() { DeleteBlogDto =  deleteBlogDto}, CancellationToken.None);
              
              (await _mockUnitOfWork.Object.BlogRepository.GetAll()).Count.ShouldBe(2);
       }
}


