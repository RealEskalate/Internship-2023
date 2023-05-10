using AutoMapper;
using BlogApp.Application.Contracts.Persistence;
using BlogApp.Application.Features._Tags.CQRS.Commands;
using BlogApp.Application.Features._Tags.CQRS.Handlers;
using BlogApp.Application.Features.Blogs.CQRS.Commands;
using BlogApp.Application.Features.Blogs.CQRS.Handlers;
using BlogApp.Application.Profiles;
using BlogApp.Application.Responses;
using BlogApp.UnitTests.Mocks;
using MediatR;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BlogApp.UnitTests.Tags
{
    public class Delete_TagCommandHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IUnitOfWork> _mockUow;
        private readonly Delete_TagCommandHandler _handler;

        public Delete_TagCommandHandlerTests()
        {
            _mockUow = MockUnitOfWork.GetUnitOfWork();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
            _handler = new Delete_TagCommandHandler(_mockUow.Object, _mapper);
        }

        [Fact]
        public async Task Valid_TagDeletionTest()
        {
            var response = await _handler.Handle(new Delete_TagCommand()
            {
                Id = 2
            }, CancellationToken.None);

            response.ShouldNotBeNull();
            response.ShouldBeOfType<BaseResponse<Unit>>();
            response.Success.ShouldBeTrue();
        }

        [Fact]
        public async Task Invalid_TagDeletionTest()
        {
            var response = await _handler.Handle(new Delete_TagCommand()
            {
                Id = 4000
            }, CancellationToken.None);

            response.ShouldNotBeNull();
            response.ShouldBeOfType<BaseResponse<Unit>>();
            response.Success.ShouldBeFalse();
        }
    }
}
