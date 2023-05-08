using BlogApp.Application.Contracts.Persistence;
using BlogApp.Application.Features.Blog.DTOs;
using BlogApp.Application.Features.Blog.CQRS.Handlers.Commands;
using BlogApp.Application.Features.Blog.CQRS.Requests.Commands;
using BlogApp.Application.Profiles;
using AutoMapper;
using BlogApp.Application.Tests.Mocks;
using Shouldly;
using Moq;
using Xunit;
using BlogApp.Tests.Mocks;

namespace BlogApp.Tests.Blog.Command;

public class UpdateBlogCommandHandlerTest
{
    private IMapper _mapper { get; set; }
    private Mock<IUnitOfWork> _mockUnitOfWork { get; set; }
    private UpdateBlogCommandHandler _handler { get; set; }


    public UpdateBlogCommandHandlerTest()
    {
        _mockUnitOfWork = MockUnitOfWork.GetUnitOfWork();

        _mapper = new MapperConfiguration(c =>
        {
            c.AddProfile<MappingProfile>();
        }).CreateMapper();

        _handler = new UpdateBlogCommandHandler(_mockUnitOfWork.Object, _mapper);
    }


    [Fact]
    public async Task UpdateBlogValid()
    {

        UpdateBlogDto updateBlogDto = new()
        {
            Title = "Title of the updated Blog",
            Content = "Body of the updated blog",
            Publish = true,
        };

        var result = await _handler.Handle(new UpdateBlogCommand() { UpdateBlogDto = updateBlogDto }, CancellationToken.None);

        result.Value.Content.ShouldBeEquivalentTo(updateBlogDto.Content);
        result.Value.Title.ShouldBeEquivalentTo(updateBlogDto.Title);

        (await _mockUnitOfWork.Object.BlogRepository.GetAll()).Count.ShouldBe(3);
    }
}


