using AutoMapper;
using MediatR;
using Moq;
using Shouldly;
using CineFlex.Application.UnitTest.Mocks;
using CineFlex.Application.Contracts.Persistence;
using CineFlex.Application.Profiles;
using Xunit;
using CineFlex.Application.Features.Seats.CQRS.Handlers;
using CineFlex.Application.Features.Seats.CQRS.Commands;
using CineFlex.Application.Responses;

namespace CineFlex.Application.UnitTest.Seattest.Command
{
    public class DeleteSeatCommandHandlerTest
    {
        

        private readonly IMapper _mapper;
        private readonly Mock<IUnitOfWork> _mockRepo;
        private int _id { get; set; }
        private readonly DeleteSeatCommandHandler _handler;
        public DeleteSeatCommandHandlerTest()
        {
            _mockRepo = MockUnitOfWork.GetUnitOfWork();
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });
            _mapper = mapperConfig.CreateMapper();
            _id = 1;

            _handler = new DeleteSeatCommandHandler(_mockRepo.Object, _mapper);

        }


        [Fact]
        public async Task DeleteSeat()
        {
           var result = await _handler.Handle(new DeleteSeatCommand() { Id = _id }, CancellationToken.None);
            result.ShouldBeOfType<BaseCommandResponse<Unit>>();
            result.Success.ShouldBeTrue();

            var Seats = await _mockRepo.Object.SeatRepository.GetAll();
            Seats.Count().ShouldBe(1);
        }

        [Fact]
        public async Task Delete_Seat_Doesnt_Exist()
        {

            _id = 0;
            var result = await _handler.Handle(new DeleteSeatCommand() { Id = _id }, CancellationToken.None);
            result.ShouldBe(null);

            var Seats = await _mockRepo.Object.SeatRepository.GetAll();
            Seats.Count.ShouldBe(2);

        }
    }
}



