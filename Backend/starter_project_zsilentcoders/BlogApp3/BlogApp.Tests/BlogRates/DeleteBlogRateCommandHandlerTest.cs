using Application.Features.Blog.Handlers.Commands;
using BlogApp.Application.Contracts.Persistence;
using BlogApp.Application.Features.Blog.DTOs;
using BlogApp.Application.Features.Blog.CQRS.Requests.Commands;
using BlogApp.Application.Profiles;
using AutoMapper;
using Shouldly;
using Moq;
using Xunit;
using BlogApp.Application.Features.BlogRates.CQRS.Commands;
using BlogApp.Application.Features.BlogRates.DTOs;
using Application.Features.BlogRates.Handlers.Commands;
using BlogApp.Tests.Mocks;

namespace BlogApp.Tests.Blog.Command;

public class DeleteBlogRateCommandHandlerTest
{
    private IMapper _mapper { get; set; }
    private Mock<IUnitOfWork> _mockUnitOfWork { get; set; }
    private DeleteBlogRateCommandHandler _handler { get; set; }

    public DeleteBlogRateCommandHandlerTest()
    {
        _mockUnitOfWork = MockUnitOfWork.GetUnitOfWork();

        _mapper = new MapperConfiguration(c =>
        {
            c.AddProfile<MappingProfile>();
        }).CreateMapper();

        _handler = new DeleteBlogRateCommandHandler(_mockUnitOfWork.Object, _mapper);
    }


    [Fact]
    public async Task DeleteBlogRateValid()
    {

        DeleteBlogRateDto deleteBlogRateDto = new() { BlogId = 1 , RaterId = 2};

        var result = await _handler.Handle(new DeleteBlogRateCommand() { DeleteBlogRateDto = deleteBlogRateDto }, CancellationToken.None);
        
        (await _mockUnitOfWork.Object.BlogRateRepository.GetAll()).Count.ShouldBe(1);
        

    }

    [Fact]
    public async Task DeleteBlogRateInvalid()
    {

        DeleteBlogRateDto deleteBlogRateDto = new () { BlogId = 100 , RaterId = 200};

        var result = await _handler.Handle(new DeleteBlogRateCommand() { DeleteBlogRateDto = deleteBlogRateDto }, CancellationToken.None);

        (await _mockUnitOfWork.Object.BlogRateRepository.GetAll()).Count.ShouldBe(2);
    }
}


