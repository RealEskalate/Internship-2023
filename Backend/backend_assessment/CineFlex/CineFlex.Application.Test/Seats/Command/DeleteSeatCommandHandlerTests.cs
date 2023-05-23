using CineFlex.Application.Contracts.Persistence;
using CineFlex.Application.Features.Seats.CQRS.Commands;
using CineFlex.Application.Features.Seats.CQRS.Handlers;
using CineFlex.Application.Responses;
using CineFlex.Domain;
using Moq;
using Shouldly;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace CineFlex.Application.Tests.Seats.CQRS.Commands
{
    public class DeleteSeatCommandHandlerTests
    {
        private readonly Mock<ISeatRepository> _mockSeatRepository;
        private readonly DeleteSeatCommandHandler _handler;
        private Seat seat;

        public DeleteSeatCommandHandlerTests()
        {
            _mockSeatRepository = new Mock<ISeatRepository>();
            _handler = new DeleteSeatCommandHandler(_mockSeatRepository.Object);
            _createHandler = new CreateSeatCommandHandler(_mockSeatRepository.Object);
            var seatDto = new CreateSeatDto { Row = 0, Number = 2, IsReserved = false, SeatLevel = "Standard", CinemaId = 1 };
            var command = new CreateSeatCommand { SeatDto = seatDto };
            seat = await _handler.Handle(command, CancellationToken.None);

        }

        [Fact]
        public async Task Handle_ValidId_ShouldReturnSuccessResponse()
        {
            // Arrange
            _mockSeatRepository.Setup(r => r.Delete(seat)).ReturnsAsync(1);

            var command = new DeleteSeatCommand { Id = seat.Id };

            // Act
            var response = await _handler.Handle(command, CancellationToken.None);

            // Assert
            response.ShouldNotBeNull();
            response.Success.ShouldBeTrue();
            response.Message.ShouldBe("Seat deleted successfully.");
        }

        [Fact]
        public async Task Handle_InvalidId_ShouldReturnFailureResponse()
        {
            // Arrange
            int seatId = 100;
            var invalid_seat = new CreateSeatDto { Row = 120, Number = 2213, IsReserved = false, SeatLevel = "Standard", CinemaId = 1 };
            _mockSeatRepository.Setup(r => r.Delete(invalid_seat)).ReturnsAsync(0);

            var command = new DeleteSeatCommand { Id = seatId };

            // Act
            var response = await _handler.Handle(command, CancellationToken.None);

            // Assert
            response.ShouldNotBeNull();
            response.Success.ShouldBeFalse();
            response.Message.ShouldBe("Seat not found.");
        }
    }
}
