using AutoMapper;
using CineFlex.Application.Contracts.Persistence;
using CineFlex.Application.Features.Seats.CQRS.Commands;
using CineFlex.Application.Features.Seats.CQRS.Handlers;
using CineFlex.Application.Features.Seats.DTOs;
using CineFlex.Application.Profiles;
using CineFlex.Application.Responses;
using CineFlex.Application.UnitTest.Mocks;
using CineFlex.Domain;
using Moq;
using Shouldly;
using Xunit;

namespace CineFlex.Application.UnitTest.Seattest.Command
{
    public class CreateSeatCommandHandlerTest
    {

        private readonly IMapper _mapper;
        private readonly Mock<IUnitOfWork> _mockRepo;
        private readonly CreateSeatDto _SeatDto;
        private readonly CreateSeatCommandHandler _handler;
        public CreateSeatCommandHandlerTest()
        {
            _mockRepo = MockUnitOfWork.GetUnitOfWork();
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });
            _mapper = mapperConfig.CreateMapper();

            _SeatDto = new CreateSeatDto
            {
                CinemaId = 1,
                Free = true,
                SeatNo = 1,
            };

            _handler = new CreateSeatCommandHandler(_mockRepo.Object, _mapper);

        }


        [Fact]
        public async Task CreateSeat()
        {
            var result = await _handler.Handle(new CreateSeatCommand() { SeatDto = _SeatDto }, CancellationToken.None);
            result.ShouldBeOfType<BaseCommandResponse<int>>();
            result.Success.ShouldBeTrue();

            var Seats = await _mockRepo.Object.SeatRepository.GetAll();
            Seats.Count.ShouldBe(3);

        }

        [Fact]
        public async Task InvalidSeat_Added()
        {

            _SeatDto.SeatNo = -1;
            var result = await _handler.Handle(new CreateSeatCommand() { SeatDto = _SeatDto }, CancellationToken.None);
            result.ShouldBeOfType<BaseCommandResponse<int>>();
            result.Success.ShouldBeFalse();
            result.Errors.ShouldNotBeEmpty();
            var Seats = await _mockRepo.Object.SeatRepository.GetAll();
            Seats.Count.ShouldBe(2);

        }
    }
}




