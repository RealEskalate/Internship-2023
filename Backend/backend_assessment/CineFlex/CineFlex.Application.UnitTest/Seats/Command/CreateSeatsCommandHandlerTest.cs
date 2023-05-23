using CineFlex.Application.Contracts.Persistence;
using CineFlex.Application.Features.Seats.DTOs;
using CineFlex.Application.Features.Seats.CQRS.Commands;
using CineFlex.Application.Features.Seats.CQRS.Handlers;
using CineFlex.Application.Profiles;
using AutoMapper;
using CineFlex.Tests.Mocks;
using Shouldly;
using Moq;
using Xunit;
using CineFlex.Tests.Mocks;
using CineFlex.Tests.Mocks;

namespace CineFlex.Tests.Seats.Command;

public class CreateSeatsCommandHandlerTest
{
       private IMapper _mapper { get; set; }
       private Mock<IUnitOfWork> _mockUnitOfWork { get; set; }
       private CreateSeatsCommandHandler _handler { get; set; }
       

       public CreateSeatsCommandHandlerTest()
       {
              _mockUnitOfWork = MockUnitOfWork.GetUnitOfWork();
              
              _mapper = new MapperConfiguration(c =>
              {
                     c.AddProfile<MappingProfile>();
              }).CreateMapper();

              _handler = new CreateSeatsCommandHandler(_mockUnitOfWork.Object, _mapper);
       }
       
       
       [Fact]
       public async Task CreateSeatValid()
       {
       
              CreateSeatsDto createSeatsDto = new()
              {

                CinemaId = 1,
                RowNumber = 3,
                SeatNumber = 4,
                IsOccupied = true,
                SeatType = "",
                Price = 300, 
                     
              };
              
              var result = await _handler.Handle(new CreateSeatsCommand() { CreateSeatsDto = createSeatsDto }, CancellationToken.None);
              
              result.Value.ShouldBeEquivalentTo(createSeatsDto.CinemaId);
              
              (await _mockUnitOfWork.Object.SeatsRepository.GetAll()).Count.ShouldBe(3);
       }
       
       [Fact]
       public async Task CreateSeatInvalid()
       {
       
              CreateSeatsDto createSeatsDto = new()
              {
                     CinemaId = 1,
                RowNumber = 3,
                SeatNumber = 4,
                IsOccupied = true,
                SeatType = "",
                Price = 300, 
              };
              
              var result = await _handler.Handle(new CreateSeatsCommand() { CreateSeatsDto = createSeatsDto }, CancellationToken.None);
              
              result.ShouldBe(null);
       }
}


