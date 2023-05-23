using AutoMapper;
using CineFlex.Application.Contracts.Persistence;
using CineFlex.Application.Features.Seat.CQRS.Commands;
using CineFlex.Application.Features.Seat.CQRS.Handlers;
using CineFlex.Application.Features.Seat.DTOs;
using CineFlex.Application.Profiles;
using CineFlex.Application.Responses;
using CineFlex.Application.UnitTest.Mocks;
using Moq;
using Shouldly;
using Xunit;

namespace CineFlex.Application.UnitTest.Seats.Commands;

public class DeleteSeatCommandHandlerTest
{
    private readonly IMapper _mapper;
    private readonly Mock<IUnitOfWork> _mockRepo;
    private int _id { get; set; }
    private readonly DeleteSeatCommandHandler _handler;
    private readonly DeleteSeatDto _rateDto;
    public DeleteSeatCommandHandlerTest()
    {
        _mockRepo = MockUnitOfWork.GetUnitOfWork();
        var mapperConfig = new MapperConfiguration(c =>
        {
            c.AddProfile<MappingProfile>();
        });
        _mapper = mapperConfig.CreateMapper();
        _rateDto = new DeleteSeatDto
        {
            Id = 1,
        };
        _id = 1;
        _handler = new DeleteSeatCommandHandler(_mockRepo.Object, _mapper);
    }
    [Fact]
    public async Task DeleteBlog()
    {
        /* var create_result = await _handler.Handle(new CreateRateCommand(){ RateDto = _rateDto  }, CancellationToken.None);*/
        var result = await _handler.Handle(new DeleteSeatCommand() { deleteSeatDto = _rateDto}, CancellationToken.None);
        result.Success.ShouldBeTrue();
        var Blogs = await _mockRepo.Object.SeatRepository.GetAll();
        Blogs.Count().ShouldBe(1);
    }
   
}