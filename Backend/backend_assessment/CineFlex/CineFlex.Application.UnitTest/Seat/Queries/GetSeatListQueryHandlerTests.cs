using AutoMapper;
using Moq;
using Shouldly;
using CineFlex.Application.Contracts.Persistence;
using CineFlex.Application.Exceptions;
using CineFlex.Application.Features.Seats.CQRS.Handlers;
using CineFlex.Application.Features.Seats.CQRS.Queries;
using CineFlex.Application.Profiles;
using CineFlex.Tests.Mocks;
using Xunit;

namespace CineFlex.Tests.Seat.Queries;

public class GetSeatListQueryHandlerTests
{
    private readonly IMapper _mapper;

    private readonly Mock<IUnitOfWork> _mockUnitOfWork;

    private readonly GetSeatListQueryHandler _handler;

    public GetSeatListQueryHandlerTests()
    {
        _mockUnitOfWork = MockUnitOfWork.GetUnitOfWork();

        var mapperConfig = new MapperConfiguration(c =>
        {
            c.AddProfile<MappingProfile>();
        });

        _mapper = mapperConfig.CreateMapper();
        _handler = new GetSeatListQueryHandler(_mockUnitOfWork.Object, _mapper);


    }

    [Fact]
    public async Task ShouldGetSeatList()
    {
        var Query = new GetSeatListQuery()
        {
        };

        var result = await _handler.Handle(Query, CancellationToken.None);
        result.Value.ShouldNotBe(null);
    }



}
