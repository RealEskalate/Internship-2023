using CineFlex.Application.Features.Seats.CQRS.Handlers;
using CineFlex.Application.Contracts.Persistence;
using CineFlex.Application.Features.Seats.DTOs;
using CineFlex.Application.Features.Seats.CQRS.Commands;
using CineFlex.Application.Profiles;
using AutoMapper;
using CineFlex.Tests.Mocks;
using Shouldly;
using Moq;

using Xunit;
using CineFlex.Tests.Mocks;

namespace CineFlex.Tests.Seats.Command;  

public class DeleteSeatsCommandHandlerTest
{
       private IMapper _mapper { get; set; }
       private Mock<IUnitOfWork> _mockUnitOfWork { get; set; }
       private DeleteSeatsCommandHandler _handler { get; set; }

       public DeleteSeatsCommandHandlerTest()
       {
              _mockUnitOfWork = MockUnitOfWork.GetUnitOfWork();
              
              _mapper = new MapperConfiguration(c =>
              {
                     c.AddProfile<MappingProfile>();
              }).CreateMapper();

              _handler = new DeleteSeatsCommandHandler(_mockUnitOfWork.Object, _mapper);
       }
       
       
       [Fact]
       public async Task DeleteSeatsValid()
       {
       
              DeleteSeatsDto deleteSeatsDto = new() { Id = 1 };
              
              var result = await _handler.Handle(new DeleteSeatsCommand() { DeleteSeatsDto =  deleteSeatsDto}, CancellationToken.None);
              
              (await _mockUnitOfWork.Object.SeatsRepository.GetAll()).Count.ShouldBe(1);
       }
       
       [Fact]
       public async Task DeleteSeatsInvalid()
       {
       
              DeleteSeatsDto deleteSeatsDto = new() { Id = 100 };
              
              var result = await _handler.Handle(new DeleteSeatsCommand() { DeleteSeatsDto =  deleteSeatsDto}, CancellationToken.None);
              
              (await _mockUnitOfWork.Object.SeatsRepository.GetAll()).Count.ShouldBe(2);
       }
}


