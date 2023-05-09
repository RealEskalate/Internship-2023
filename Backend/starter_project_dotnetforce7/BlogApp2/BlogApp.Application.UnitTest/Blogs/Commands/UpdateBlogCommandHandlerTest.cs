using AutoMapper;
using BlogApp.Application.Contracts.Persistence;
using BlogApp.Application.Features.Blogs.CQRS.Commands;
using BlogApp.Application.Features.Blogs.CQRS.Handlers;
using BlogApp.Application.Features.Blogs.DTOs;
using BlogApp.Application.Profiles;
using BlogApp.Application.Responses;
using BlogApp.Application.UnitTest.Mocks;
using MediatR;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Application.UnitTest.Blogs.Commands

{
    public class UpdateBlogCommandHandlerTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<IUnitOfWork> _mockRepo;
        private readonly UpdateBlogDto _BlogDto;
        private readonly UpdateBlogCommandHandler _handler;
        public UpdateBlogCommandHandlerTest()
        {
            _mockRepo = MockUnitOfWork.GetUnitOfWork();
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });
            _mapper = mapperConfig.CreateMapper();

            _BlogDto = new UpdateBlogDto
            {
                 Id = 1,
                Title = "blog title21 updated",
                Content = "Blog Content updated",
                CoverImage = "blog image",
                PublicationStatus= true
            };

            _handler = new UpdateBlogCommandHandler(_mockRepo.Object, _mapper);

        }


        [Fact]
        public async Task UpdateBlog()
        {
            var result = await _handler.Handle(new UpdateBlogCommand() { BlogDto = _BlogDto }, CancellationToken.None);
            result.ShouldBeOfType<Result<Unit>>();
            result.Success.ShouldBeTrue();

            var blog = await _mockRepo.Object.BlogRepository.Get(_BlogDto.Id);
            blog.Title.Equals(_BlogDto.Title);
            blog.Content.Equals(_BlogDto.Content);
        }

        [Fact]
        public async Task Update_With_Invalid_PulicationStatus()
        {

            _BlogDto.PublicationStatus = null;
            var result = await _handler.Handle(new UpdateBlogCommand() { BlogDto = _BlogDto }, CancellationToken.None);
            result.ShouldBeOfType<Result<Unit>>();
            result.Success.ShouldBeFalse();

            result.Errors.ShouldNotBeEmpty();
            var Blogs = await _mockRepo.Object.BlogRepository.GetAll();
            Blogs.Count.ShouldBe(2);

        }


    }
}



