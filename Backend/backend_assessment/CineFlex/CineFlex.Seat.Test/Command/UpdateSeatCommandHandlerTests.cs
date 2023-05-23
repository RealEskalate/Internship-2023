using CineFlex.Application.Contracts.Persistence;
using CineFlex.Application.Features.Seats.CQRS.Commands;
using CineFlex.Application.Features.Seats.DTOs;
using CineFlex.Application.Responses;
using MediatR;
using Moq;
using Shouldly;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace CineFlex.Tests.Seats.CQRS.Commands
{
    public class UpdateSeatCommandHandlerTests
    {
        private readonly Mock<ISeatRepository> _mockSeatRepository;
        private readonly UpdateSeatCommandHandler _handler;

        public UpdateSeatCommandHandlerTests()
        {
            _mockSeatRepository = new Mock<ISeatRepository>();
            _handler = new UpdateSeatCommandHandler(_mockSeatRepository.Object);
        }

        [Fact]
        public async Task Handle_ValidSeatDto_ShouldReturnSuccessResponse()
        {
            // Arrange
            var seatId = 1;
            var updatedSeatDto = new UpdateSeatDto
            {
                Id = seatId,
                Row = 2,
                Number = 3,
                IsReserved = true,
                SeatLevel = "Premium",
                CinemaId = 1
            };
            var command = new UpdateSeatCommand { SeatDto = updatedSeatDto };
            _mockSeatRepository.Setup(r => r.UpdateAsync(updatedSeatDto)).ReturnsAsync(true);

            // Act
            var response = await _handler.Handle(command, CancellationToken.None);

            // Assert
            response.ShouldNotBeNull();
            response.Success.ShouldBeTrue();
            response.Value.ShouldBe(Unit.Value);
        }

        [Fact]
        public async Task Handle_InvalidSeatDto_ShouldReturnFailureResponse()
        {
            // Arrange
            var seatId = 100;
            var updatedSeatDto = new UpdateSeatDto
            {
                Id = seatId,
                Row = 2,
                Number = 3,
                IsReserved = true,
                SeatLevel = "Premium",
                CinemaId = 1
            };
            var command = new UpdateSeatCommand { SeatDto = updatedSeatDto };
            _mockSeatRepository.Setup(r => r.UpdateAsync(updatedSeatDto)).ReturnsAsync(false);

            // Act
            var response = await _handler.Handle(command, CancellationToken.None);

            // Assert
            response.ShouldNotBeNull();
            response.Success.ShouldBeFalse();
            response.Errors.ShouldContain("Failed to update seat.");
        }
    }
}
