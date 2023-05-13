using AutoMapper;
using BlogApp.Application.Contracts.Identity;
using BlogApp.Application.Contracts.Persistence;
using BlogApp.Application.Features.Blogs.CQRS.Handlers;
using BlogApp.Application.Features.Blogs.CQRS.Queries;
using BlogApp.Application.Features.Blogs.DTOs;
using BlogApp.Application.Models.Identity;
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

namespace BlogApp.Application.UnitTest.Blogs.Queries
{
    public class GetBlogListQueryHandlerTest
    {

        private readonly IMapper _mapper;
        private readonly Mock<IUnitOfWork> _mockRepo;
        private readonly GetBlogListQueryHandler _handler;

        private readonly Mock<IUserService> _mockUserService;
        public GetBlogListQueryHandlerTest()
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


            _handler = new GetBlogListQueryHandler(_mockRepo.Object, _mapper, _mockUserService.Object);

        }


        [Fact]
        public async Task GetBlogList()
        {
            var result = await _handler.Handle(new GetBlogListQuery(), CancellationToken.None);
            result.ShouldBeOfType<Result<List<BlogDto>>>();
            Console.WriteLine("result", result);
            result.Value.Count.ShouldBe(2);
        }
    }
}



