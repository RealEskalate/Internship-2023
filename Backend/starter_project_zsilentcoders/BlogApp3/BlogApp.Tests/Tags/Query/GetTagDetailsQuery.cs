using BlogApp.Application.Contracts.Persistence;
using BlogApp.Application.Features.Tags.CQRS.Handlers;
using BlogApp.Application.Features.Tags.CQRS.Queries;
using BlogApp.Application.Profiles;
using AutoMapper;
using BlogApp.Application.Tests.Mocks;
using Shouldly;
using Moq;
using BlogApp.Tests.Mocks;
using Xunit;

namespace BlogApp.Tests.Tags.Query;

public class GetTagDetailsQueryHandlerTest
{
    private IMapper _mapper { get; set; }
    private Mock<IUnitOfWork> _mockUnitOfWork{ get; set; }  
    private GetTagDetailsQueryHandler _handler { get; set; }

    public GetTagDetailsQueryHandlerTest()
    { 
        _mockUnitOfWork = MockUnitOfWork.GetUnitOfWork();
              
        _mapper = new MapperConfiguration(c =>
        {
            c.AddProfile<MappingProfile>();
        }).CreateMapper();

        _handler = new GetTagDetailsQueryHandler(_mockUnitOfWork.Object, _mapper);
    }

    [Fact]
    public async Task GetTagDetailsValid()
    {
        var result = await _handler.Handle(new GetTagDetailsQuery() { Id = 2}, CancellationToken.None);
        result.ShouldNotBe(null);
    }
       
    [Fact]
    public async Task GetTagDetailsInvalid()
    {
        var result = await _handler.Handle(new GetTagDetailsQuery() { Id = 100}, CancellationToken.None);
        result.Value.ShouldBe(null);
    }
}


