namespace CineFlex.Application.UnitTest.Seats.Queries;

using AutoMapper;
using CineFlex.Application.Contracts.Persistence;
using CineFlex.Application.Features.Seat.CQRS.Handlers;
using CineFlex.Application.Features.Seat.CQRS.Queries;
using CineFlex.Application.Features.Seat.DTOs;
using CineFlex.Application.Profiles;
using CineFlex.Application.Responses;
using CineFlex.Application.UnitTest.Mocks;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

public class GetSeatListQueryHandlerTest
{

    private readonly IMapper _mapper;
    private readonly Mock<IUnitOfWork> _mockRepo;
    private readonly GetListSeatQueryHandler _handler;
    public GetSeatListQueryHandlerTest()
    {
        _mockRepo = MockUnitOfWork.GetUnitOfWork();
        var mapperConfig = new MapperConfiguration(c =>
        {
            c.AddProfile<MappingProfile>();
        });
        _mapper = mapperConfig.CreateMapper();

        _handler = new GetListSeatQueryHandler(_mockRepo.Object, _mapper);

    }


    [Fact]
    public async Task GetBlogList()
    {
        var result = await _handler.Handle(new GetSeatListQuery(), CancellationToken.None);
        result.ShouldBeOfType<BaseCommandResponse<List<SeatDto>>>();
        Console.WriteLine("result", result);
        result.Value.Count.ShouldBe(2);
    }
}



