using CineFlex.Application.Contracts.Persistence;
using CineFlex.Application.Features.Seats.CQRS.Queries;
using CineFlex.Application.Features.Seats.CQRS.Handlers;
using CineFlex.Application.Features.Seats.DTOs;
using CineFlex.Application.Responses;
using MediatR;
using Moq;
using Shouldly;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace CineFlex.Application.Test.Seats.CQRS.Queries
{
    public class GetSeatListQueryHandlerTests
    {
        private readonly Mock<ISeatRepository> _mockSeatRepository;
        private readonly GetSeatListQueryHandler _handler;

        public GetSeatListQueryHandlerTests()
        {
            _mockSeatRepository = new Mock<ISeatRepository>();
            _handler = new GetSeatListQueryHandler(_mockSeatRepository.Object);
        }

        [Fact]
        public async Task Handle_ReturnsSeatList()
        {
            // Arrange
            var seats = new List<SeatDto>
            {
                new SeatDto { Id = 1, Row = 1, Number = 1, IsReserved = false, SeatLevel = "Standard", CinemaId = 1 },
                new SeatDto { Id = 2, Row = 1, Number = 2, IsReserved = true, SeatLevel = "VIP", CinemaId = 1 },
                new SeatDto { Id = 3, Row = 2, Number = 1, IsReserved = false, SeatLevel = "Standard", CinemaId = 1 }
            };
            _mockSeatRepository.Setup(repo => repo.GetAll()).ReturnsAsync(seats);

            var query = new GetSeatListQuery();

            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            result.ShouldNotBeNull();
            result.Success.ShouldBeTrue();
            result.Value.ShouldNotBeNull();
            result.Value.Count.ShouldBe(seats.Count);
            result.Value.ShouldContain(seat => seat.Id == 1);
            result.Value.ShouldContain(seat => seat.Id == 2);
            result.Value.ShouldContain(seat => seat.Id == 3);
        }
    }
}
