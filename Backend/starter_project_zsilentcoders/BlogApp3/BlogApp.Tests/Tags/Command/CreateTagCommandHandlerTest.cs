using BlogApp.Application.Contracts.Persistence;
using BlogApp.Application.Features.Tags.DTOs;
using BlogApp.Application.Features.Tags.CQRS.Commands;
using BlogApp.Application.Features.Tags.CQRS.Handlers;
using BlogApp.Application.Profiles;
using AutoMapper;
using BlogApp.Tests.Mocks;
using Shouldly;
using Moq;
using Xunit;
using BlogApp.Tests.Mocks;

namespace BlogApp.Tests.Tags.Command;

public class CreateTagCommandHandlerTest
{
       private IMapper _mapper { get; set; }
       private Mock<IUnitOfWork> _mockUnitOfWork { get; set; }
       private CreateTagCommandHandler _handler { get; set; }
       

       public CreateTagCommandHandlerTest()
       {
              _mockUnitOfWork = MockUnitOfWork.GetUnitOfWork();
              
              _mapper = new MapperConfiguration(c =>
              {
                     c.AddProfile<MappingProfile>();
              }).CreateMapper();

              _handler = new CreateTagCommandHandler(_mockUnitOfWork.Object, _mapper);
       }
       
       
       [Fact]
       public async Task CreateTagValid()
       {
       
              CreateTagDto createTagDto = new()
              {
                     Title = "Title of Tag",
                     Description = "Body of Tag",
                     
              };
              
              var result = await _handler.Handle(new CreateTagCommand() { CreateTagDto = createTagDto }, CancellationToken.None);
              
              result.Value.Description.ShouldBeEquivalentTo(createTagDto.Description);
              result.Value.Title.ShouldBeEquivalentTo(createTagDto.Title);
              
              (await _mockUnitOfWork.Object.TagRepository.GetAll()).Count.ShouldBe(3);
       }
       
       [Fact]
       public async Task CreateTagInvalid()
       {
       
              CreateTagDto createTagDto = new()
              {
                     Title = "", 
                     Description = "Description of the Tag",
                   
              };
              
              var result = await _handler.Handle(new CreateTagCommand() { CreateTagDto = createTagDto }, CancellationToken.None);
              
              result.Value.ShouldBe(null);
       }
}


