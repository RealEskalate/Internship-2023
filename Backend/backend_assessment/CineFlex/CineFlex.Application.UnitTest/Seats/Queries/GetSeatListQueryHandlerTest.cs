using AutoMapper;
using CineFlex.Application.Contracts.Persistence;
using CineFlex.Application.Features.Seats.CQRS.Handlers;
using CineFlex.Application.Features.Seats.CQRS.Queries;
using CineFlex.Application.Features.Seats.Dtos;
using CineFlex.Application.Responses;
using CineFlex.Domain;
using Moq;
using Shouldly;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace CineFlex.Application.UnitTest.Seats.Queries
{
    public class GetSeatListQueryHandlerTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<IUnitOfWork> _mockUnitOfWork;
        private readonly GetSeatListQueryHandler _handler;

        public GetSeatListQueryHandlerTest()
        {
            _mockUnitOfWork = new Mock<IUnitOfWork>();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<Profiles.MappingProfile>();
            });
            _mapper = mapperConfig.CreateMapper();

            _handler = new GetSeatListQueryHandler(_mockUnitOfWork.Object, _mapper);
        }

        [Fact]
        public async Task Handle_NoSeats_ReturnsFailureResponse()
        {
            // Arrange
            var cancellationToken = CancellationToken.None;
            var emptySeatList = new List<SeatEntity>();
            _mockUnitOfWork.Setup(u => u.SeatRepository.GetAll()).ReturnsAsync(emptySeatList);

            // Act
            var response = await _handler.Handle(new GetSeatListQuery(), cancellationToken);

            // Assert
            response.ShouldNotBeNull();
            response.ShouldBeOfType<BaseCommandResponse<List<SeatDto>>>();
            response.Success.ShouldBeFalse();
            response.Message.ShouldBe("No Seat found.");
            response.Value.ShouldBeNull();

            _mockUnitOfWork.Verify(u => u.SeatRepository.GetAll(), Times.Once);
        }

        [Fact]
        public async Task Handle_WithSeats_ReturnsSuccessResponse()
        {
            // Arrange
            var cancellationToken = CancellationToken.None;
            var seats = new List<SeatEntity>
            {
                new SeatEntity { Id = 1 },
                new SeatEntity { Id = 2 }
            };
            _mockUnitOfWork.Setup(u => u.SeatRepository.GetAll()).ReturnsAsync(seats);

            // Act
            var response = await _handler.Handle(new GetSeatListQuery(), cancellationToken);

            // Assert
            response.ShouldNotBeNull();
            response.ShouldBeOfType<BaseCommandResponse<List<SeatDto>>>();
            response.Success.ShouldBeTrue();
            response.Message.ShouldBeNull();
            response.Value.ShouldNotBeNull();
            response.Value.ShouldBeOfType<List<SeatDto>>();
            response.Value.Count.ShouldBe(2);
            response.Value.Any(s => s.Id == 1).ShouldBeTrue();
            response.Value.Any(s => s.Id == 2).ShouldBeTrue();

        }
    }
}
