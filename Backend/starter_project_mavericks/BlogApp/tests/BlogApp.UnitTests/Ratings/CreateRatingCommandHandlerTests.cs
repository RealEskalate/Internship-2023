using AutoMapper;
using BlogApp.Application.Contracts.Persistence;
using BlogApp.Application.Exceptions;
using BlogApp.Application.Features.Ratings.CQRS.Commands;
using BlogApp.Application.Features.Ratings.CQRS.Handlers;
using BlogApp.Application.Features.Ratings.DTOs;
using BlogApp.Application.Profiles;
using BlogApp.Application.Responses;
using BlogApp.UnitTests.Mocks;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BlogApp.UnitTests.Ratings;
public class CreateRatingCommandHandlerTests
{
    private readonly IMapper _mapper;
    private readonly Mock<IUnitOfWork> _mockUow;
    private readonly RatingDto _ratingDto;
    private readonly RatingDto _invalidRatingDto;
    private readonly CreateRatingCommandHandler _handler;

    public CreateRatingCommandHandlerTests()
    {
        _mockUow = MockUnitOfWork.GetUnitOfWork();

        var mapperConfig = new MapperConfiguration(c =>
        {
            c.AddProfile<MappingProfile>();
        });

        _mapper = mapperConfig.CreateMapper();
        _handler = new CreateRatingCommandHandler(_mockUow.Object, _mapper);

        _ratingDto = new RatingDto
        {
            Rate = 6
        };
        _invalidRatingDto = new RatingDto { Rate = 11 };
    }

    [Fact]
    public async Task Valid_Rate_Created()
    {
        var response = await _handler.Handle(new CreateRatingCommand() { BlogId = 1, RatingDto = _ratingDto }, CancellationToken.None);
        response.ShouldBeOfType<BaseResponse<Nullable<int>>>();
        response.ShouldNotBeNull();
        response.Success.ShouldBeTrue();
        response.Data.ShouldBe(6);
    }

    [Fact]
    public async Task InValid_Rate_Created()
    {
        var response = await _handler.Handle(new CreateRatingCommand() { BlogId = 1, RatingDto = _invalidRatingDto }, CancellationToken.None);
        response.ShouldNotBeNull();
        response.Success.ShouldBeFalse();
    }
}
