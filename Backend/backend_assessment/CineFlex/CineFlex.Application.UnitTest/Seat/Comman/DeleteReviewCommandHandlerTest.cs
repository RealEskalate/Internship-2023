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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CineFlex.Application.UnitTest.Seats.Command
{
    public class DeleteSeatCommandHandlerTest
    {

        private readonly IMapper _mapper;
        private readonly Mock<IUnitOfWork> _mockRepo;
        private int _id { get; set; }
        private readonly DeleteSeatCommandHandler _handler;
        private readonly CreateSeatDto _seatDto;
        public DeleteSeatCommandHandlerTest()
        {
            _mockRepo = MockUnitOfWork.GetUnitOfWork();
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });
            _mapper = mapperConfig.CreateMapper();
            _seatDto = new CreateSeatDto
            {
             SeatNumber = 1,
             SeatType = "VIP",
             isAvailable = false,
             CinemaId = 3
            };
            _id = 1;

            _handler = new DeleteSeatCommandHandler(_mockRepo.Object, _mapper);

        }


        [Fact]
        public async Task DeleteSeat()
        {
            /* var create_result = await _handler.Handle(new CreateRateCommand(){ RateDto = _rateDto  }, CancellationToken.None);*/

            var result = await _handler.Handle(new DeleteSeatCommand() { Id = _id }, CancellationToken.None);
            result.ShouldBeOfType<BaseCommandResponse<Unit>>();
            result.Success.ShouldBeTrue();

            var seats = await _mockRepo.Object.SeatRepository.GetAll();
            seats.Count().ShouldBe(2);
        }

        [Fact]
        public async Task Delete_Seat_Doesnt_Exist()
        {

            _id  = -1;
            var result = await _handler.Handle(new DeleteSeatCommand() { Id = _id }, CancellationToken.None);
            result.ShouldBe(null);
        
            var seats = await _mockRepo.Object.SeatRepository.GetAll();
            seats.Count.ShouldBe(3);

        }
    }
}



