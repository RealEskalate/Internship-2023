using BlogApp.Application.Contracts.Persistence;
using BlogApp.Application.Features.Blog.DTOs;
using BlogApp.Application.Features.Blog.CQRS.Handlers.Commands;
using BlogApp.Application.Features.Blog.CQRS.Requests.Commands;
using BlogApp.Application.Profiles;
using AutoMapper;
using BlogApp.Application.Tests.Mocks;
using Shouldly;
using Moq;
using Xunit;
using BlogApp.Tests.Mocks;

namespace BlogApp.Tests.Blog.Command;

public class CreateBlogCommandHandlerTest
{
       private IMapper _mapper { get; set; }
       private Mock<IUnitOfWork> _mockUnitOfWork { get; set; }
       private CreateBlogCommandHandler _handler { get; set; }
       

       public CreateBlogCommandHandlerTest()
       {
              _mockUnitOfWork = MockUnitOfWork.GetUnitOfWork();
              
              _mapper = new MapperConfiguration(c =>
              {
                     c.AddProfile<MappingProfile>();
              }).CreateMapper();

              _handler = new CreateBlogCommandHandler(_mockUnitOfWork.Object, _mapper);
       }
       
       
       [Fact]
       public async Task CreateBlogValid()
       {
       
              CreateBlogDto createBlogDto = new()
              {
                     Title = "Title of the new Blog",
                     Content = "Body of the new blog",
                     Publish = true,
              };
              
              var result = await _handler.Handle(new CreateBlogCommand() { CreateBlogDto = createBlogDto }, CancellationToken.None);
              
              result.Value.Content.ShouldBeEquivalentTo(createBlogDto.Content);
              result.Value.Title.ShouldBeEquivalentTo(createBlogDto.Title);
              
              (await _mockUnitOfWork.Object.BlogRepository.GetAll()).Count.ShouldBe(3);
       }
       
       [Fact]
       public async Task CreateBlogInvalid()
       {
       
              CreateBlogDto createBlogDto = new()
              {
                     Title = "", // Title can't be empty 
                     Content = "Body of the new blog",
                     Publish = true,
              };
              
              var result = await _handler.Handle(new CreateBlogCommand() { CreateBlogDto = createBlogDto }, CancellationToken.None);
              
              result.Value.ShouldBe(null);
       }
}


