using CineFlex.Application.Contracts.Persistence;
using CineFlex.Application.Features.Seats.CQRS.Commands;
using CineFlex.Application.Responses;
using Moq;
using Shouldly;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace CineFlex.Tests.Seats.CQRS.Commands
{
    public class DeleteSeatCommandHandlerTests
    {
        private readonly Mock<ISeatRepository> _mockSeatRepository;
        private readonly DeleteSeatCommandHandler _handler;

        public DeleteSeatCommandHandlerTests()
        {
            _mockSeatRepository = new Mock<ISeatRepository>();
            _handler = new DeleteSeatCommandHandler(_mockSeatRepository.Object);
        }

        [Fact]
        public async Task Handle_ValidId_ShouldReturnSuccessResponse()
        {
            // Arrange
            int seatId = 1;
            _mockSeatRepository.Setup(r => r.DeleteAsync(seatId)).ReturnsAsync(1);

            var command = new DeleteSeatCommand { Id = seatId };

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
            _mockSeatRepository.Setup(r => r.DeleteAsync(seatId)).ReturnsAsync(0);

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
