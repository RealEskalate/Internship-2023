using AutoMapper;
using BlogApp.Application.Contracts.Persistence;
using BlogApp.Application.Features.Reviews.CQRS.Commands;
using BlogApp.Application.Features.Reviews.CQRS.Handlers;
using BlogApp.Application.Profiles;
using BlogApp.Application.Responses;
using BlogApp.UnitTests.Mocks;
using MediatR;
using Moq;
using Shouldly;
using Xunit;

namespace BlogApp.UnitTests.Blogs
{
    public class DeleteReviewCommandHandlerTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<IUnitOfWork> _mockUow;
        private readonly DeleteReviewCommandHandler _handler;

        public DeleteReviewCommandHandlerTest()
        {
            _mockUow = MockUnitOfWork.GetUnitOfWork();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
            _handler = new DeleteReviewCommandHandler(_mockUow.Object,_mapper);
        }
        
        [Fact]
        public async Task ValidReviewDeletionTest()
        {
            var response = await _handler.Handle(new DeleteReviewCommand() {
                Id = 2
            }, CancellationToken.None);

            response.ShouldNotBeNull();
            response.ShouldBeOfType<BaseResponse<Unit>>();
            response.Success.ShouldBeTrue();   
        }

        [Fact]
        public async Task InvalidReviewDeletionTest()
        {
            var response = await _handler.Handle(new DeleteReviewCommand() {
                Id = 4000
            }, CancellationToken.None);
            
            response.ShouldNotBeNull();
            response.ShouldBeOfType<BaseResponse<Unit>>();
            response.Success.ShouldBeFalse();    
        }
    }
}