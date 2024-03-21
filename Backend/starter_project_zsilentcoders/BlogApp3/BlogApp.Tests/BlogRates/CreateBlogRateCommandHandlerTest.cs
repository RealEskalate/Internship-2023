using BlogApp.Application.Contracts.Persistence;
using BlogApp.Application.Features.BlogRates.DTOs;
using BlogApp.Application.Features.BlogRates.CQRS.Commands;
using BlogApp.Application.Profiles;
using AutoMapper;
using Shouldly;
using Moq;
using Xunit;
using BlogApp.Tests.Mocks;
using BlogApp.Application.Features.BlogRates.CQRS.Handlers;
using Microsoft.EntityFrameworkCore.Query;
using BlogApp.Application.Features.Blog.DTOs;

namespace BlogApp.Tests.BlogRates;

public class CreateBlogRateCommandHandlerTest
{
    private IMapper _mapper { get; set; }
    private Mock<IUnitOfWork> _mockUnitOfWork { get; set; }
    private CreateBlogRateCommandHandler _handler { get; set; }


    public CreateBlogRateCommandHandlerTest()
    {
        _mockUnitOfWork = MockUnitOfWork.GetUnitOfWork();

        _mapper = new MapperConfiguration(c =>
        {
            c.AddProfile<MappingProfile>();
        }).CreateMapper();

        _handler = new CreateBlogRateCommandHandler(_mockUnitOfWork.Object, _mapper);
    }


    [Fact]
    public async Task CreateBlogRateValid()
    {

        CreateBlogRateDto createBlogRateDto = new()
        {
            RaterId = 4,
            BlogId = 1,
            RateNo = 3,
        };

        var result = await _handler.Handle(new CreateBlogRateCommand() { CreateBlogRateDto = createBlogRateDto }, CancellationToken.None);

        result.Value.RaterId.ShouldBeEquivalentTo(createBlogRateDto.RaterId);
        result.Value.BlogId.ShouldBeEquivalentTo(createBlogRateDto.BlogId);
        result.Value.RateNo.ShouldBeEquivalentTo(createBlogRateDto.RateNo);


        (await _mockUnitOfWork.Object.BlogRateRepository.GetAll()).Count.ShouldBe(3);
    }

    [Fact]
    public async Task CreateBlogRateInvalid()
    {

        CreateBlogRateDto createBlogRateDto = new()
        {
            RaterId = 0 ,
            BlogId = 0,
            RateNo = 0,
        };

        var result = await _handler.Handle(new CreateBlogRateCommand() { CreateBlogRateDto = createBlogRateDto }, CancellationToken.None);

        result.Value.ShouldBe(null);
    }
}


