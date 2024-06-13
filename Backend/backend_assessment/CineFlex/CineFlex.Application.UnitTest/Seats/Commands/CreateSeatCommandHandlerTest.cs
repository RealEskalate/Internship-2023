namespace CineFlex.Application.UnitTest.Seats.Commands;

using AutoMapper;
using CineFlex.Application.Contracts.Persistence;
using CineFlex.Application.Features.Seat.CQRS.Commands;
using CineFlex.Application.Features.Seat.CQRS.Handlers;
using CineFlex.Application.Features.Seat.DTOs;
using CineFlex.Application.Profiles;
using CineFlex.Application.Responses;
using CineFlex.Application.UnitTest.Mocks;
using CineFlex.Domain;
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


public class CreateSeatCommandHandlerTest
{

    private readonly IMapper _mapper;
    private readonly Mock<IUnitOfWork> _mockRepo;
    private readonly CreateSeatDto _seatsDto;
    private readonly CreateSeatCommandHandler _handler;
    public CreateSeatCommandHandlerTest()
    {
        _mockRepo = MockUnitOfWork.GetUnitOfWork();
        var mapperConfig = new MapperConfiguration(c =>
        {
            c.AddProfile<MappingProfile>();
        });
        _mapper = mapperConfig.CreateMapper();

        _seatsDto = new CreateSeatDto
        {
            SeatNumber = "123",
            SeatType = SeatType.VIP,
            Availability = Availability.Taken,
        };

        _handler = new CreateSeatCommandHandler(_mockRepo.Object, _mapper);

    }


    [Fact]
    public async Task CreateBlog()
    {
        var result = await _handler.Handle(new CreateSeatCommand() { createSeatDto = _seatsDto }, CancellationToken.None);
        result.ShouldBeOfType<BaseCommandResponse<int>>();
        Console.WriteLine("result: ", result);
        result.Success.ShouldBeTrue();

        var Blogs = await _mockRepo.Object.SeatRepository.GetAll();
        Blogs.Count.ShouldBe(3);

    }

    [Fact]
    public async Task InvalidBlog_Added()
    {

    
        var result = await _handler.Handle(new CreateSeatCommand() { createSeatDto = _seatsDto }, CancellationToken.None);
        result.ShouldBeOfType<BaseCommandResponse<int>>();
        result.Success.ShouldBeFalse();
        result.Errors.ShouldNotBeEmpty();
        var Seats = await _mockRepo.Object.SeatRepository.GetAll();
        Seats.Count.ShouldBe(2);

    }
}



