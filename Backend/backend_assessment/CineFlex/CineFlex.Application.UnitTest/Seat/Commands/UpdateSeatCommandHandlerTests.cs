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

namespace CineFlex.Tests.Seat.Commands
{
    public class UpdateSeatCommandHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IUnitOfWork> _mockUnitOfWork;

        private readonly UpdateSeatCommandHandler _handler;

        public UpdateSeatCommandHandlerTests()
        {
            _mockUnitOfWork = MockUnitOfWork.GetUnitOfWork();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
            _handler = new UpdateSeatCommandHandler(_mockUnitOfWork.Object, _mapper);

        }

        [Fact]
        public async Task ShouldUpdate_WhenValidRequestMade()
        {
            var command = new UpdateSeatCommand()
            {
                SeatDto = new UpdateSeatDto
                {
                    Id = 1,
                    CinemaId = 1,
                    Available = true,
                    SeatLocation = "43E"
                }
            };

            var result = await _handler.Handle(command, CancellationToken.None);
            var Seat = await _mockUnitOfWork.Object.SeatRepository.Get(1);

            result.ShouldNotBe(null);
            result.Success.ShouldBe(true);

            Seat.Available.ShouldBe(true);
            Seat.SeatLocation.ShouldBe("43E");

            var Seats = await _mockUnitOfWork.Object.SeatRepository.GetAll();
            Seats.Count.ShouldBe(2);
        }

        [Fact]
        public async Task ShouldThrowError_WhenInvalidRequestMade()
        {
            var command = new UpdateSeatCommand()
            {
                SeatDto = new UpdateSeatDto
                {
                    CinemaId = 0,
                    Available = true,
                    SeatLocation = "43E"
                }
            };

            var result = await _handler.Handle(command, CancellationToken.None);
            var Seat = await _mockUnitOfWork.Object.SeatRepository.GetAll();

            result.ShouldNotBe(null);
            result.Success.ShouldBe(false);
            Seat.Count.ShouldBe(2);

        }
    }
}
