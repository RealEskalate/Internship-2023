using AutoMapper;
using CineFlex.Application.Contracts.Persistence;
using CineFlex.Application.Exceptions;
using CineFlex.Application.Features.Seats.CQRS.Handlers;
using CineFlex.Application.Features.Seats.CQRS.Queries;
using CineFlex.Application.Features.Seats.Dtos;
using CineFlex.Application.Responses;
using CineFlex.Domain;
using Moq;
using Shouldly;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace CineFlex.Application.UnitTest.Seats.Queries
{
    public class GetSeatQueryHandlerTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<IUnitOfWork> _mockUnitOfWork;
        private readonly int _seatId;
        private readonly GetSeatQueryHandler _handler;

        public GetSeatQueryHandlerTest()
        {
            _mockUnitOfWork = new Mock<IUnitOfWork>();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<Profiles.MappingProfile>();
            });
            _mapper = mapperConfig.CreateMapper();

            _seatId = 1;

            _handler = new GetSeatQueryHandler(_mockUnitOfWork.Object, _mapper);
        }

        [Fact]
        public async Task Handle_ExistingSeatId_ReturnsSuccessResponse()
        {
            // Arrange
            var cancellationToken = CancellationToken.None;
            var existingSeat = new SeatEntity { Id = _seatId };
            _mockUnitOfWork.Setup(u => u.SeatRepository.Exists(_seatId)).ReturnsAsync(true);
            _mockUnitOfWork.Setup(u => u.SeatRepository.Get(_seatId)).ReturnsAsync(existingSeat);

            // Act
            var response = await _handler.Handle(new GetSeatQuery { Id = _seatId }, cancellationToken);

            // Assert
            response.ShouldNotBeNull();
            response.ShouldBeOfType<BaseCommandResponse<SeatDto>>();
            response.Success.ShouldBeTrue();
            response.Message.ShouldBe("Seat Fetch Success");
            response.Value.ShouldNotBeNull();
            response.Value.ShouldBeOfType<SeatDto>();
            response.Value.Id.ShouldBe(_seatId);

           
        }

        [Fact]
        public async Task Handle_NonExistingSeatId_ReturnsFailureResponse()
        {
            // Arrange
            var nonExistingSeatId = 0;
            var cancellationToken = CancellationToken.None;
            _mockUnitOfWork.Setup(u => u.SeatRepository.Exists(nonExistingSeatId)).ReturnsAsync(false);
            var expectedError = new NotFoundException(nameof(Seats), nonExistingSeatId);

            // Act
            var response = await _handler.Handle(new GetSeatQuery { Id = nonExistingSeatId }, cancellationToken);

            // Assert
            response.ShouldNotBeNull();
            response.ShouldBeOfType<BaseCommandResponse<SeatDto>>();
            response.Success.ShouldBeFalse();
            response.Message.ShouldBe("Seat Fetch Failed");
            response.Errors.ShouldNotBeNull();
            response.Errors.ShouldBeOfType<List<string>>();
            response.Errors.ShouldContain(expectedError.Message);

           
        }
    }
}
