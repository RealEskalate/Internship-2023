using AutoMapper;
using BlogApp.Application.Contracts.Persistence;
using BlogApp.Application.Features.Blogs.CQRS.Handlers;
using BlogApp.Application.Features.Blogs.CQRS.Commands;
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
    public class DeleteBlogCommandHandlerTest
    {

        private readonly IMapper _mapper;
        private readonly Mock<IUnitOfWork> _mockRepo;
        private int _id { get; set; }
        private readonly DeleteBlogCommandHandler _handler;
        private readonly CreateBlogDto _rateDto;
        public DeleteBlogCommandHandlerTest()
        {
            _mockRepo = MockUnitOfWork.GetUnitOfWork();
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });
            _mapper = mapperConfig.CreateMapper();
            _rateDto = new CreateBlogDto
            {
                Title = "blog title 3",
                Content = "Blog Content 3",
                CoverImage = "blog image 3",
                PublicationStatus= false
            };
            _id = 1;

            _handler = new DeleteBlogCommandHandler(_mockRepo.Object, _mapper);

        }


        [Fact]
        public async Task DeleteBlog()
        {
            /* var create_result = await _handler.Handle(new CreateRateCommand(){ RateDto = _rateDto  }, CancellationToken.None);*/

            var result = await _handler.Handle(new DeleteBlogCommand() { Id = _id }, CancellationToken.None);
            result.ShouldBeOfType<Result<int>>();
            result.Success.ShouldBeTrue();

            var Blogs = await _mockRepo.Object.BlogRepository.GetAll();
            Blogs.Count().ShouldBe(1);
        }

        [Fact]
        public async Task Delete_Blog_Doesnt_Exist()
        {

            _id  = 0;
            var result = await _handler.Handle(new DeleteBlogCommand() { Id = _id }, CancellationToken.None);
            result.ShouldBeOfType<Result<int>>();
            result.Success.ShouldBeFalse();
            var Blogs = await _mockRepo.Object.BlogRepository.GetAll();
            Blogs.Count.ShouldBe(2);

        }
    }
}



