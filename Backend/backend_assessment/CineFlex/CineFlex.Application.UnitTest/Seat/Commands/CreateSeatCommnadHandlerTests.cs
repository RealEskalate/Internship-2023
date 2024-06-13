using AutoMapper;
using CineFlex.Application.Contracts.Persistence;
using CineFlex.Application.Features.Seats.CQRS.Commands;
using CineFlex.Application.Features.Seats.DTOs;
using CineFlex.Application.Profiles;
using CineFlex.Tests.Mocks;
using CineFlex.Application.Features.Seats.CQRS.Handlers;
using CineFlex.Application.Exceptions;
using Shouldly;
using Moq;
using Xunit;

namespace CineFlex.Tests.Seat.Commands;

public class CreateSeatCommandHandlerTests
{
    private readonly IMapper _mapper;
    private readonly Mock<IUnitOfWork> _mockUnitOfWork;

    private readonly CreateSeatCommandHandler _handler;

    public CreateSeatCommandHandlerTests()
    {
        _mockUnitOfWork = MockUnitOfWork.GetUnitOfWork();

        var mapperConfig = new MapperConfiguration(c =>
        {
            c.AddProfile<MappingProfile>();
        });

        _mapper = mapperConfig.CreateMapper();
        _handler = new CreateSeatCommandHandler(_mockUnitOfWork.Object, _mapper);

    }

    [Fact]
    public async Task Valid_Seat_Added()
    {
        var command = new CreateSeatCommand()
        {
            SeatDto = new CreateSeatDto
            {
                CinemaId = 1,
                Available = true,
                SeatLocation = "55D"
            }
        };

        var result = await _handler.Handle(command, CancellationToken.None);
        var Seat = await _mockUnitOfWork.Object.SeatRepository.GetAll();

        result.ShouldNotBe(null);
        result.Success.ShouldBe(true);
        result.Value.ShouldBeOfType<int>();

        Seat.Count.ShouldBe(3);
    }

    [Fact]
    public async Task InValid_Seat_Added()
    {

        var command = new CreateSeatCommand()
        {
            SeatDto = new CreateSeatDto
            {
                CinemaId = 1,
                Available = true,
                SeatLocation = ""
            }
        };

        var result = await _handler.Handle(command, CancellationToken.None);
        var Seat = await _mockUnitOfWork.Object.SeatRepository.GetAll();

        result.ShouldNotBe(null);
        result.Success.ShouldBe(false);
        Seat.Count.ShouldBe(2);

    }
}

