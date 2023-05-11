using Application.Features.BlogRates.Handlers.Commands;
using AutoMapper;
using BlogApp.Application.Contracts.Persistence;
using BlogApp.Application.Features.BlogRates.CQRS.Handlers;
using BlogApp.Application.Features.BlogRates.CQRS.Queries;
using BlogApp.Application.Features.BlogRates.DTOs;
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

namespace BlogApp.Tests.BlogRates
{
    public class GetBlogRateListByBlogRequestHandlerTest
    {
        private IMapper _mapper { get; set; }
        private Mock<IUnitOfWork> _mockUnitOfWork { get; set; }
        private GetBlogRateListByBlogRequestHandler _handler { get; set; }

        public GetBlogRateListByBlogRequestHandlerTest()
        {
            _mockUnitOfWork = MockUnitOfWork.GetUnitOfWork();

            _mapper = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            }).CreateMapper();

            _handler = new GetBlogRateListByBlogRequestHandler(_mockUnitOfWork.Object, _mapper);
        }

        [Fact]
        public async Task GetBlogRateListByBlogValid()
        {
            var request = new GetBlogRateListByBlogRequest { BlogId = 1 };

            var result = await _handler.Handle(request, CancellationToken.None);

            result.Value.ShouldBeOfType<List<BlogRateDto>>();


            

        }


        [Fact]

        public async Task GetBlogRateListByBlogInvalid()
        {
            var request = new GetBlogRateListByBlogRequest { BlogId= 100 };
            var result = await _handler.Handle(request, CancellationToken.None);
            result.Value.Count.ShouldBe(0);

        }


    }
}
