using BlogApp.Application.Features.Tags.CQRS.Handlers;
using BlogApp.Application.Contracts.Persistence;
using BlogApp.Application.Features.Tags.DTOs;
using BlogApp.Application.Features.Tags.CQRS.Commands;
using BlogApp.Application.Profiles;
using AutoMapper;
using BlogApp.Tests.Mocks;
using Shouldly;
using Moq;
using BlogApp.Tests.Mocks;
using Xunit;
using Application.Features.Tags.CQRS.Handlers;

namespace BlogApp.Tests.Tags.Command;  

public class DeleteTagCommandHandlerTest
{
       private IMapper _mapper { get; set; }
       private Mock<IUnitOfWork> _mockUnitOfWork { get; set; }
       private DeleteTagCommandHandler _handler { get; set; }

       public DeleteTagCommandHandlerTest()
       {
              _mockUnitOfWork = MockUnitOfWork.GetUnitOfWork();
              
              _mapper = new MapperConfiguration(c =>
              {
                     c.AddProfile<MappingProfile>();
              }).CreateMapper();

              _handler = new DeleteTagCommandHandler(_mockUnitOfWork.Object, _mapper);
       }
       
       
       [Fact]
       public async Task DeleteTagValid()
       {
       
              DeleteTagDto deleteTagDto = new() { Id = 1 };
              
              var result = await _handler.Handle(new DeleteTagCommand() { DeleteTagDto =  deleteTagDto}, CancellationToken.None);
              
              (await _mockUnitOfWork.Object.TagRepository.GetAll()).Count.ShouldBe(1);
       }
       
       [Fact]
       public async Task DeleteTagInvalid()
       {
       
              DeleteTagDto deleteTagDto = new() { Id = 100 };
              
              var result = await _handler.Handle(new DeleteTagCommand() { DeleteTagDto =  deleteTagDto}, CancellationToken.None);
              
              (await _mockUnitOfWork.Object.TagRepository.GetAll()).Count.ShouldBe(2);
       }
}


