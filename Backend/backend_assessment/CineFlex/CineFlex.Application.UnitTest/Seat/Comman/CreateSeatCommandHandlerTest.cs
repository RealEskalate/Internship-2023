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
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CineFlex.Application.UnitTest.Rates.Command
{
    public class CreateSeatCommandHandlerTest
    {

        private readonly IMapper _mapper;
        private readonly Mock<IUnitOfWork> _mockRepo;
        private readonly CreateSeatDto _seatDto;
        private readonly CreateSeatCommandHandler _handler;
        public CreateSeatCommandHandlerTest()
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

            _handler = new CreateSeatCommandHandler(_mockRepo.Object, _mapper);

        }


        [Fact]
        public async Task CreateSeat()
        {
            var result = await _handler.Handle(new CreateSeatCommand() { SeatDto = _seatDto }, CancellationToken.None);
            result.ShouldBeOfType<BaseCommandResponse<int>>();
            result.Success.ShouldBeTrue();

            var seats = await _mockRepo.Object.SeatRepository.GetAll();
            seats.Count.ShouldBe(4);

        }

        [Fact]
        public async Task InvalidSeat_Added()
        {

            _seatDto.SeatType = "";
            var result = await _handler.Handle(new CreateSeatCommand() { SeatDto = _seatDto }, CancellationToken.None);
            result.Success.ShouldBeFalse();
            result.Errors.ShouldNotBeEmpty();
            var seats = await _mockRepo.Object.SeatRepository.GetAll();
            seats.Count.ShouldBe(3);

        }
    }
}




