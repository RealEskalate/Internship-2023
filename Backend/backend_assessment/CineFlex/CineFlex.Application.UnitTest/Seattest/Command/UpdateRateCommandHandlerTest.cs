using AutoMapper;
using CineFlex.Application.Contracts.Persistence;
using CineFlex.Application.Features.Seats.CQRS.Commands;
using CineFlex.Application.Features.Seats.CQRS.Handlers;
using CineFlex.Application.Features.Seats.DTOs;
using CineFlex.Application.Profiles;
using CineFlex.Application.Responses;
using CineFlex.Application.UnitTest.Mocks;
using MediatR;
using Moq;
using Shouldly;
using Xunit;

namespace BlogApp.Application.UnitTest.Seattest.Command
{
    public class UpdateSeatCommandHandlerTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<IUnitOfWork> _mockRepo;
        private readonly UpdateSeatStatusDto _SeatDto;
        private readonly UpdateSeatStatusCommandHandler _handler;
        public UpdateSeatCommandHandlerTest()
        {
            _mockRepo = MockUnitOfWork.GetUnitOfWork();
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });
            _mapper = mapperConfig.CreateMapper();

            _SeatDto = new UpdateSeatStatusDto
            {
                Id = 1,
                Free = false,
            };

            _handler = new UpdateSeatStatusCommandHandler(_mockRepo.Object, _mapper);

        }


        [Fact]
        public async Task UpdateSeat()
        {
            var result = await _handler.Handle(new UpdateSeatStatusCommand() { SeatDto = _SeatDto }, CancellationToken.None);
            result.ShouldBeOfType<BaseCommandResponse<Unit>>();
            result.Success.ShouldBeTrue();

            var Seat = await _mockRepo.Object.SeatRepository.Get(_SeatDto.Id);
            Seat.Id.Equals(_SeatDto.Id);
        }

        [Fact]
        public async Task Update_With_Invalid_SeatNO()
        {

            _SeatDto.Id = -1;
            var result = await _handler.Handle(new UpdateSeatStatusCommand() { SeatDto = _SeatDto }, CancellationToken.None);
            result.ShouldBeOfType<BaseCommandResponse<Unit>>();
            result.Success.ShouldBeFalse();

            var Seats = await _mockRepo.Object.SeatRepository.GetAll();
            Seats.Count.ShouldBe(2);

        }


    }
}



