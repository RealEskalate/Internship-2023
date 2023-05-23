using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CineFlex.Application.Contracts.Persistence;
using CineFlex.Application.Features.Seats.CQRS.Commands;
using CineFlex.Application.Features.Seats.CQRS.Handlers;
using CineFlex.Application.Features.Seats.DTOs;
using CineFlex.Application.Profiles;
using CineFlex.Application.Responses;
using CineFlex.Application.UnitTest.Mocks;
using FluentAssertions;
using Moq;
using Shouldly;
using Xunit;

namespace CineFlex.Application.UnitTest.Seats.Commands;

     public class CreateSeatCommandHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IUnitOfWork> _mockUow;
        private readonly CreateSeatDto _seatDto;
        private readonly CreateSeatDto _invalidSeatDto;

        private readonly CreateSeatCommandHandler _handler;

        public CreateSeatCommandHandlerTests()
        {
            _mockUow = MockUnitOfWork.GetUnitOfWork();
            
            var mapperConfig = new MapperConfiguration(c => 
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
            _handler = new CreateSeatCommandHandler(_mockUow.Object, _mapper);

            _seatDto = new CreateSeatDto
            {
                Id = 1,
                SeatNumber = 2
            };

            _invalidSeatDto = new CreateSeatDto
            {
                Id = 2,
                SeatNumber = 0
            };
        }

        [Fact]
        public async Task Valid_Seat_Added()
        {
            var result = await _handler.Handle(new CreateSeatCommand() { CreateSeatDto = _seatDto }, CancellationToken.None);

            var seats = await _mockUow.Object.SeatRepository.GetAll();

            result.ShouldBeOfType<BaseCommandResponse<int>>();

            seats.Count.ShouldBe(3);
        }

        [Fact]
        public async Task InValid_Seat_Added()
        {

            var result = await _handler.Handle(new CreateSeatCommand() { CreateSeatDto = _invalidSeatDto}, CancellationToken.None);

            var seats = await _mockUow.Object.SeatRepository.GetAll();
            
            seats.Count.ShouldBe(2);

            result.ShouldBeOfType<BaseCommandResponse<int>>();
            
        }
    }

