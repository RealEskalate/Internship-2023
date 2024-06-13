using AutoMapper;
using Moq;
using Shouldly;
using CineFlex.Application.Contracts.Persistence;
using CineFlex.Application.Exceptions;
using CineFlex.Application.Features.Seats.CQRS.Handlers;
using CineFlex.Application.Features.Seats.CQRS.Commands;
using CineFlex.Application.Features.Seats.DTOs;
using CineFlex.Application.Profiles;
using CineFlex.Tests.Mocks;
using Xunit;

namespace CineFlex.Tests.Seat.Commands;

public class DeleteSeatCommandHandlerTests
{
    private readonly IMapper _mapper;

    private readonly Mock<IUnitOfWork> _mockUnitOfWork;

    private readonly DeleteSeatCommandHandler _handler;

    public DeleteSeatCommandHandlerTests()
    {
        _mockUnitOfWork = MockUnitOfWork.GetUnitOfWork();

        var mapperConfig = new MapperConfiguration(c =>
        {
            c.AddProfile<MappingProfile>();
        });

        _mapper = mapperConfig.CreateMapper();
        _handler = new DeleteSeatCommandHandler(_mockUnitOfWork.Object, _mapper);

    }

    [Fact]
    public async Task ShouldDeleteSeatWhenIdExists()
    {

        var command = new DeleteSeatCommand()
        {
            Id = 1
        };

        var result = await _handler.Handle(command, CancellationToken.None);
        var Seat = await _mockUnitOfWork.Object.SeatRepository.GetAll();

        result.ShouldNotBe(null);
        result.Success.ShouldBe(true);
        Seat.Count.ShouldBe(1);

    }


    [Fact]
    public async Task ShouldReturnFalseWhenSeatDoesNotEist()
    {

        var command = new DeleteSeatCommand()
        {
            Id = 0
        };
        
        var result = await _handler.Handle(command, CancellationToken.None);
        var Seat = await _mockUnitOfWork.Object.SeatRepository.GetAll();

        result.ShouldNotBe(null);
        result.Success.ShouldBe(false);
        Seat.Count.ShouldBe(2);

    }

}
