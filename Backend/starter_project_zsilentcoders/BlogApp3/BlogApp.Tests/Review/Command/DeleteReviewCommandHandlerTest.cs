using AutoMapper;
using BlogApp.Application.Contracts.Persistence;
using BlogApp.Application.Exceptions;
using BlogApp.Application.Features.Review.CQRS.Command;
using BlogApp.Application.Features.Review.CQRS.Commands;
using BlogApp.Application.Features.Review.CQRS.Handlers;
using BlogApp.Application.Features.Review.DTOs;
using BlogApp.Application.Profiles;
using BlogApp.Application.Tests.Mocks;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BlogApp.Tests.Review.Command
{
    public class DeleteReviewCommandHandlerTest
    {
        private IMapper _mapper { get; set; }
        private Mock<IUnitOfWork> _mockUnitOfWork { get; set; }
        private DeleteReviewCommandHandler _handler { get; set; }


        public DeleteReviewCommandHandlerTest()
        {
            _mockUnitOfWork = MockUnitOfWork.GetUnitOfWork();

            _mapper = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            }).CreateMapper();

            _handler = new DeleteReviewCommandHandler(_mockUnitOfWork.Object, _mapper);
        }


        [Fact]
        public async Task DeleteReviewValid()
        {

            var createReviewDto = new ReviewDto()
            {
                Id = 1

            };

            var result = await _handler.Handle(new DeleteReviewCommand() { Id = createReviewDto.Id }, CancellationToken.None);


            // the count should be 1
            var reviews = await _mockUnitOfWork.Object.ReviewRepository.GetAll();
            reviews.Count.ShouldBe(1);
        }

        [Fact]
        public async Task CreateReviewInvalid()
        {

            var createReviewDto = new ReviewDto()
            {
                Id = 10,
            };

            NotFoundException ex = await Should.ThrowAsync<NotFoundException>(async () =>
            {
                var result = await _handler.Handle(new DeleteReviewCommand() { Id = createReviewDto.Id }, CancellationToken.None);
            });
            var reviews = await _mockUnitOfWork.Object.ReviewRepository.GetAll();
            reviews.Count.ShouldBe(2);

        }
    }
}
