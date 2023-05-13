using AutoMapper;
using BlogApp.Application.Contracts.Identity;
using BlogApp.Application.Contracts.Persistence;
using BlogApp.Application.Features.Blogs.CQRS.Commands;
using BlogApp.Application.Features.Blogs.CQRS.Handlers;
using BlogApp.Application.Features.Blogs.DTOs;
using BlogApp.Application.Models.Identity;
using BlogApp.Application.Profiles;
using BlogApp.Application.Responses;
using BlogApp.Application.UnitTest.Mocks;

using MediatR;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xunit;

namespace BlogApp.Application.UnitTest.Blogs.Commands
{
    public class CreateBlogCommandHandlerTest
    {

        private readonly IMapper _mapper;
        private readonly Mock<IUnitOfWork> _mockRepo;
        private readonly CreateBlogDto _blogDto;
        private readonly CreateBlogCommandHandler _handler;

        private readonly Mock<IUserService> _mockUserService;
        public CreateBlogCommandHandlerTest()
        {
            _mockRepo = MockUnitOfWork.GetUnitOfWork();
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });
            _mapper = mapperConfig.CreateMapper();
            _mockUserService = new Mock<IUserService>();

            _mockUserService
            .Setup(us => us.GetUser(It.IsAny<string>()))
            .ReturnsAsync(new ApplicationUserDTO { Id = "fb8656da-2b94-474f-8709-85e0cd7ea903"});


            _blogDto = new CreateBlogDto
            {
                Title = "blog title 3",
                Content = "Blog Content 3",
                CoverImage = "blog image 3",
                PublicationStatus= true,
        };

            _handler = new CreateBlogCommandHandler(_mockRepo.Object, _mapper, _mockUserService.Object);

        }


        [Fact]
        public async Task CreateBlog()
        {
            var result = await _handler.Handle(new CreateBlogCommand() { BlogDto = _blogDto }, CancellationToken.None);

            result.ShouldBeOfType<Result<int>>();
            result.Success.ShouldBeTrue();

            var Blogs = await _mockRepo.Object.BlogRepository.GetAll();
            Blogs.Count.ShouldBe(3);

        }

        [Fact]
        public async Task InvalidBlog_Added()
        {

            _blogDto.PublicationStatus = null;
            var result = await _handler.Handle(new CreateBlogCommand() { BlogDto = _blogDto }, CancellationToken.None);
            result.ShouldBeOfType<Result<int>>();
            result.Success.ShouldBeFalse();
            result.Errors.ShouldNotBeEmpty();
            var Blogs = await _mockRepo.Object.BlogRepository.GetAll();
            Blogs.Count.ShouldBe(2);

        }
    }
}




