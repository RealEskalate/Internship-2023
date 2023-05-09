using AutoMapper;
using BlogApp.Application.Contracts.Persistence;
using BlogApp.Application.Features.Comments.CQRS.Commands;
using BlogApp.Application.Features.Comments.CQRS.Handlers;
using BlogApp.Application.Features.Comments.CQRS.Queries;
using BlogApp.Application.Features.Comments.DTOs;
using BlogApp.Application.Profiles;
using BlogApp.Application.Responses;
using BlogApp.UnitTests.Mocks;
using MediatR;
using Moq;
using Shouldly;
using Xunit;

namespace BlogApp.UnitTests.Comments
{
    public class DeleteCommentCommandHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IUnitOfWork> _mockUow;
        private readonly DeleteCommentCommandHandler _handler;

        public DeleteCommentCommandHandlerTests()
        {
            _mockUow = MockUnitOfWork.GetUnitOfWork();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
            _handler = new DeleteCommentCommandHandler( _mockUow.Object,_mapper);
        }
        
        [Fact]
        public async Task ValidCommentDeletionTest()
        {
            var response = await _handler.Handle(new DeleteCommentCommand() {
                Id = 3
            }, CancellationToken.None);

            response.ShouldNotBeNull();
            response.ShouldBeOfType<BaseResponse<Unit>>();
            
        }

        [Fact]
        public async Task InvalidCommentDeletionTest()
        {
            var response = await _handler.Handle(new DeleteCommentCommand() {
                Id = 100
            }, CancellationToken.None);
            
            response.ShouldNotBeNull();
            response.ShouldBeOfType<BaseResponse<Unit>>();
            response.Success.ShouldBeFalse();    
        }
    }
}