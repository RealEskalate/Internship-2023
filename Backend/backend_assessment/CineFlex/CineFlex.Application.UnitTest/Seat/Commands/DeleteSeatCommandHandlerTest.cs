using AutoMapper;
using CineFlex.Application.Contracts.Persistence;
using CineFlex.Application.Features.Seats.CQRS.Commands;
using CineFlex.Application.Features.Seats.CQRS.Handlers;
using CineFlex.Application.Responses;
using FluentAssertions;
using Moq;
using Xunit;

namespace CineFlex.Application.UnitTest.Seat.Commands;

public class DeleteSeatCommandHandlerTests
{
    private readonly Mock<IMapper> _mockMapper;
    private readonly Mock<IUnitOfWork> _mockUnitOfWork;

    public DeleteSeatCommandHandlerTests()
    {
        _mockUnitOfWork = new Mock<IUnitOfWork>();
        _mockMapper = new Mock<IMapper>();
    }

    [Fact]
    public async Task Handle_WithValidSeatId_ShouldDeleteSeatAndReturnSuccessResponse()
    {
        // Arrange
        var command = new DeleteSeatCommand { Id = 1 };

        var handler = new DeleteSeatCommandHandler(_mockUnitOfWork.Object, _mockMapper.Object);

        var existingSeat = new Domain.Seat { Id = 1 };

        _mockUnitOfWork.Setup(uow => uow.SeatRepository.Get(command.Id)).ReturnsAsync(existingSeat);
        _mockUnitOfWork.Setup(uow => uow.SeatRepository.Delete(existingSeat));
        _mockUnitOfWork.Setup(uow => uow.Save()).ReturnsAsync(1);

        // Act
        var response = await handler.Handle(command, CancellationToken.None);

        // Assert
        response.Should().BeOfType<BaseCommandResponse<int>>();
        response.Success.Should().BeTrue();
        response.Message.Should().Be("Seat deleted successfully.");
        response.Value.Should().Be(existingSeat.Id);

        _mockUnitOfWork.Verify(uow => uow.SeatRepository.Get(command.Id), Times.Once);
        _mockUnitOfWork.Verify(uow => uow.SeatRepository.Delete(existingSeat), Times.Once);
        _mockUnitOfWork.Verify(uow => uow.Save(), Times.Once);
    }

    [Fact]
    public async Task Handle_WithInvalidSeatId_ShouldReturnFailureResponse()
    {
        // Arrange
        var command = new DeleteSeatCommand { Id = 1 };

        var handler = new DeleteSeatCommandHandler(_mockUnitOfWork.Object, _mockMapper.Object);

        _mockUnitOfWork.Setup(uow => uow.SeatRepository.Get(command.Id)).ReturnsAsync((Domain.Seat)null);

        // Act
        var response = await handler.Handle(command, CancellationToken.None);

        // Assert
        response.Should().BeOfType<BaseCommandResponse<int>>();
        response.Success.Should().BeFalse();
        response.Message.Should().Be("Seat does not exist.");

        _mockUnitOfWork.Verify(uow => uow.SeatRepository.Get(command.Id), Times.Once);
        _mockUnitOfWork.Verify(uow => uow.SeatRepository.Delete(It.IsAny<Domain.Seat>()), Times.Never);
        _mockUnitOfWork.Verify(uow => uow.Save(), Times.Never);
    }
}