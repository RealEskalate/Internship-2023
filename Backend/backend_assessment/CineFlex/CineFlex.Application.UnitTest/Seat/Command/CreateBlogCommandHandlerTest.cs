using AutoMapper;
using Shouldly;
using Moq;
using Xunit;
using BlogApp.Tests.Mocks;
using CineFlex.Application.Contracts.Persistence;
using CineFlex.Application.Features.Seats.CQRS.Handlers.Commands;
using CineFlex.Application.Features.Seats.DTOs;
using CineFlex.Application.Profiles;

namespace BlogApp.Tests.Blog.Command;

public class CreateBlogCommandHandlerTest
{
       private IMapper _mapper { get; set; }
       private Mock<IUnitOfWork> _mockUnitOfWork { get; set; }
       private CreateSeatCommandHandler _handler { get; set; }
       

       public CreateBlogCommandHandlerTest()
       {
              _mockUnitOfWork = MockUnitOfWork.GetUnitOfWork();
              
              _mapper = new MapperConfiguration(c =>
              {
                     c.AddProfile<MappingProfile>();
              }).CreateMapper();

              _handler = new CreateSeatCommandHandler(_mockUnitOfWork.Object, _mapper);
       }
       
       
       [Fact]
       public async Task CreateBlogValid()
       {
       
              CreateSeatDto createBlogDto = new()
              {
                     Movie = 1,
                     Cinema = 1,
                     Location = "dkjsd"
              };
              
              // var result = await _handler.Handle(new CreateBlogCommand() { CreateBlogDto = createBlogDto }, CancellationToken.None);
              //
              // result.Value.Content.ShouldBeEquivalentTo(createBlogDto.Content);
              // result.Value.Title.ShouldBeEquivalentTo(createBlogDto.Title);
              //
              // (await _mockUnitOfWork.Object.BlogRepository.GetAll()).Count.ShouldBe(3);
       }
       
       // [Fact]
       // public async Task CreateBlogInvalid()
       // {
       //
       //        CreateBlogDto createBlogDto = new()
       //        {
       //               Title = "", // Title can't be empty 
       //               Content = "Body of the new blog",
       //               Publish = true,
       //        };
       //        
       //        var result = await _handler.Handle(new CreateBlogCommand() { CreateBlogDto = createBlogDto }, CancellationToken.None);
       //        
       //        result.Value.ShouldBe(null);
       // }
}


