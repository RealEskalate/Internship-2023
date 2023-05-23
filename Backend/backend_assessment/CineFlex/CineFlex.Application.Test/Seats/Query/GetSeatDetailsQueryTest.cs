using CineFlex.Application.Contracts.Persistence;
using CineFlex.Application.Features.Seats.CQRS.Queries;
using CineFlex.Application.Features.Seats.CQRS.Handlers;
using CineFlex.Application.Features.Seats.DTOs;
using CineFlex.Application.Responses;
using Moq;
using Shouldly;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace CineFlex.Application.Test.Seats.CQRS.Queries
{
    public class GetSeatDetailQueryHandlerTests
    {
        private readonly Mock<ISeatRepository> _mockSeatRepository;
        private readonly GetSeatDetailQueryHandler _handler;

        public GetSeatDetailQueryHandlerTests()
        {
            _mockSeatRepository = new Mock<ISeatRepository>();
            _handler = new GetSeatDetailQueryHandler(_mockSeatRepository.Object);
        }

        [Fact]
        public async Task Handle_ValidId_ShouldReturnSeatDto()
        {
            // Arrange
            SeatDto seat = new SeatDto { Id = 1, Row = 1, Number = 1, IsReserved = false, SeatLevel = "Standard", CinemaId = 1 };

            var seatDto = new SeatDto { Id = seatId, Row = 1, Number = 2, IsReserved = false, SeatLevel = "Standard", CinemaId = 1 };
            _mockSeatRepository.Setup(r => r.GetByIdAsync(seatId)).ReturnsAsync(seatDto);

            var query = new GetSeatDetailQuery { Id = seatId };

            // Act
            var response = await _handler.Handle(query, CancellationToken.None);

            // Assert
            response.ShouldNotBeNull();
            response.Success.ShouldBeTrue();
            response.Value.ShouldNotBeNull();
            response.Value.Id.ShouldBe(seatId);
            // Assert other properties if needed
        }

        [Fact]
        public async Task Handle_InvalidId_ShouldReturnNull()
        {
            // Arrange
            SeatDto seat = new SeatDto { Id = 1, Row = 1, Number = 1, IsReserved = false, SeatLevel = "Standard", CinemaId = 1 };

            _mockSeatRepository.Setup(r => r.Get(seat)).ReturnsAsync((SeatDto)null);

            var query = new GetSeatDetailQuery { Id = seat.Id };

            // Act
            var response = await _handler.Handle(query, CancellationToken.None);

            // Assert
            response.ShouldNotBeNull();
            response.Success.ShouldBeFalse();
            response.Value.ShouldBeNull();
        }
    }
}
