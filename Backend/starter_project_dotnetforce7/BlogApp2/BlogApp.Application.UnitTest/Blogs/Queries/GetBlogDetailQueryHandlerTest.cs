using AutoMapper;
using BlogApp.Application.Contracts.Persistence;
using BlogApp.Application.Features.Blogs.CQRS.Commands;
using BlogApp.Application.Features.Blogs.CQRS.Handlers;
using BlogApp.Application.Features.Blogs.CQRS.Queries;
using BlogApp.Application.Features.Blogs.DTOs;
using BlogApp.Application.Profiles;
using BlogApp.Application.Responses;
using BlogApp.Application.UnitTest.Mocks;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BlogApp.Application.Contracts.Identity;
using BlogApp.Application.Models.Identity;

namespace BlogApp.Application.UnitTest.Blogs.Queries
{
    public class GetBlogDetailQueryHandlerTest
    {

        private readonly IMapper _mapper;
        private readonly Mock<IUnitOfWork> _mockRepo;
        private readonly Mock<IUserService> _mockUserService;
        private int Id;
        private readonly GetBlogDetailQueryHandler _handler;
        public GetBlogDetailQueryHandlerTest()
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
            .ReturnsAsync(new ApplicationUserDTO { Id = "1", UserName = "JohnDoe", Firstname="John",  Lastname="Doe", Email="John@Doe.com"});

            Id = 1;

            _handler = new GetBlogDetailQueryHandler(_mockRepo.Object, _mapper, _mockUserService.Object);

        }


        [Fact]
        public async Task GetBlogDetail()
        {
            var result = await _handler.Handle(new GetBlogDetailQuery() { Id = Id }, CancellationToken.None);
            result.ShouldBeOfType<Result<BlogDto>>();
             result.Value.ShouldBeOfType<BlogDto>();
        }

        [Fact]
       public async Task GetNonExistingBlog()
{
    // Set a non-existing Id
    var nonExistingId = 0;

    // Invoke the handler with the non-existing Id
    var result = await _handler.Handle(new GetBlogDetailQuery() { Id = nonExistingId }, CancellationToken.None);

    // Assert that the response is a NotFound result
    result.ShouldBeOfType<Result<BlogDto>>();
        result.Success.ShouldBeTrue();
    result.Value.ShouldBe(null);
}
    }
}

