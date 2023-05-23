using AutoMapper;
using CineFlex.Application.Contracts.Persistence;
using CineFlex.Application.Features.Seats.CQRS.Handlers;
using CineFlex.Application.Features.Seats.CQRS.Queries;
using CineFlex.Application.Features.Seats.DTOs;
using CineFlex.Application.Responses;
using CineFlex.Domain;
using FluentAssertions;
using Moq;
using Xunit;

namespace CineFlex.Application.UnitTest.Seat.Queries;

public class GetSeatsByCinemaQueryHandlerTests
{
    private readonly Mock<IUnitOfWork> _mockUnitOfWork;
    private readonly Mock<IMapper> _mockMapper;

    public GetSeatsByCinemaQueryHandlerTests()
    {
        _mockUnitOfWork = new Mock<IUnitOfWork>();
        _mockMapper = new Mock<IMapper>();
    }

    [Fact]
    public async Task Handle_WithExistingCinemaId_ShouldReturnSeatsSuccessfully()
    {
        // Arrange
        var query = new GetSeatsByCinemaQuery { CinemaId = 1 };

        var handler = new GetSeatsByCinemaQueryHandler(_mockUnitOfWork.Object, _mockMapper.Object);

        var existingCinema = new CinemaEntity() { Id = 1 };

        var seats = new List<Domain.Seat>
        {
            new() { Id = 1 },
            new() { Id = 2 },
            new() { Id = 3 }
        };

        _mockUnitOfWork.Setup(uow => uow.CinemaRepository.Get(query.CinemaId)).ReturnsAsync(existingCinema);
        _mockUnitOfWork.Setup(uow => uow.SeatRepository.GetByCinemaId(query.CinemaId)).ReturnsAsync(seats);
        _mockMapper.Setup(m => m.Map<List<SeatDto>>(seats)).Returns(
            new List<SeatDto>
            {
                new SeatDto { Id = 1 },
                new SeatDto { Id = 2 },
                new SeatDto { Id = 3 }
            });

        // Act
        var response = await handler.Handle(query, CancellationToken.None);

        // Assert
        response.Should().BeOfType<BaseCommandResponse<List<SeatDto>>>();
        response.Success.Should().BeTrue();
        response.Message.Should().Be("Seats retrieved successfully.");
        response.Value.Should().HaveCount(3);
        response.Value.Should().Contain(s => s.Id == 1);
        response.Value.Should().Contain(s => s.Id == 2);
        response.Value.Should().Contain(s => s.Id == 3);

        _mockUnitOfWork.Verify(uow => uow.CinemaRepository.Get(query.CinemaId), Times.Once);
        _mockUnitOfWork.Verify(uow => uow.SeatRepository.GetByCinemaId(query.CinemaId), Times.Once);
        _mockMapper.Verify(m => m.Map<List<SeatDto>>(seats), Times.Once);
    }

    [Fact]
    public async Task Handle_WithNonExistingCinemaId_ShouldReturnFailureResponse()
    {
        // Arrange
        var query = new GetSeatsByCinemaQuery { CinemaId = 1 };

        var handler = new GetSeatsByCinemaQueryHandler(_mockUnitOfWork.Object, _mockMapper.Object);

        _mockUnitOfWork.Setup(uow => uow.CinemaRepository.Get(query.CinemaId)).ReturnsAsync((CinemaEntity)null);

        // Act
        var response = await handler.Handle(query, CancellationToken.None);

        // Assert
        response.Should().BeOfType<BaseCommandResponse<List<SeatDto>>>();
        response.Success.Should().BeFalse();
        response.Message.Should().Be("Cinema does not exist.");
        response.Value.Should().BeNull();

        _mockUnitOfWork.Verify(uow => uow.CinemaRepository.Get(query.CinemaId), Times.Once);
        _mockUnitOfWork.Verify(uow => uow.SeatRepository.GetByCinemaId(query.CinemaId), Times.Never);
        _mockMapper.Verify(m => m.Map<List<SeatDto>>(It.IsAny<List<Domain.Seat>>()), Times.Never);
    }
}