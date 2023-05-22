using BlogApp.Application.Contracts.Persistence;
using BlogApp.Application.Features.Tags.DTOs;
using BlogApp.Application.Features.Tags.CQRS.Commands;
using BlogApp.Application.Features.Tags.CQRS.Handlers;
using BlogApp.Application.Profiles;
using AutoMapper;
using BlogApp.Tests.Mocks;
using Shouldly;
using Moq;
using Xunit;
using BlogApp.Tests.Mocks;

namespace BlogApp.Tests.Tags.Command;

public class UpdateTagCommandHandlerTest
{
    private IMapper _mapper { get; set; }
    private Mock<IUnitOfWork> _mockUnitOfWork { get; set; }
    private UpdateTagCommandHandler _handler { get; set; }


    public UpdateTagCommandHandlerTest()
    {
        _mockUnitOfWork = MockUnitOfWork.GetUnitOfWork();

        _mapper = new MapperConfiguration(c =>
        {
            c.AddProfile<MappingProfile>();
        }).CreateMapper();

        _handler = new UpdateTagCommandHandler(_mockUnitOfWork.Object, _mapper);
    }


    [Fact]
    public async Task UpdateTagValid()
    {

        UpdateTagDto updateTagDto = new()
        {
            Id = 1,
            Title = "Title of the updated Tag",
            Description = "Description of the updated Tag",
        
        };

        var result = await _handler.Handle(new UpdateTagCommand() { UpdateTagDto = updateTagDto }, CancellationToken.None);

        var UpdatedTag = await _mockUnitOfWork.Object.TagRepository.Get(1);

        UpdatedTag.Description.ShouldBe(updateTagDto.Description);
        UpdatedTag.Title.ShouldBe(updateTagDto.Title);

        (await _mockUnitOfWork.Object.TagRepository.GetAll()).Count.ShouldBe(2);
    }
}
