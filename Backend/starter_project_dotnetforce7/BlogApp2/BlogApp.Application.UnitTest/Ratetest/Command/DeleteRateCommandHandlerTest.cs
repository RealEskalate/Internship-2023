using AutoMapper;
using BlogApp.Application.Contracts.Persistence;
using BlogApp.Application.Features.Rates.CQRS.Handlers;
using BlogApp.Application.Features.Rates.CQRS.Commands;
using BlogApp.Application.Features.Rates.DTOs;
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

namespace BlogApp.Application.UnitTest.Ratetest.Command
{
    public class DeleteRateCommandHandlerTest
    {

        private readonly IMapper _mapper;
        private readonly Mock<IUnitOfWork> _mockRepo;
        private int _id { get; set; }
        private readonly DeleteRateCommandHandler _handler;
        private readonly CreateRateDto _rateDto;
        public DeleteRateCommandHandlerTest()
        {
            _mockRepo = MockUnitOfWork.GetUnitOfWork();
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });
            _mapper = mapperConfig.CreateMapper();
            _rateDto = new CreateRateDto
            {
                RateNo = 5,
                RaterId = 3,
                BlogId = 4
            };
            _id = 1;

            _handler = new DeleteRateCommandHandler(_mockRepo.Object, _mapper);

        }


        [Fact]
        public async Task DeleteRate()
        {
            /* var create_result = await _handler.Handle(new CreateRateCommand(){ RateDto = _rateDto  }, CancellationToken.None);*/

            var result = await _handler.Handle(new DeleteRateCommand() { Id = _id }, CancellationToken.None);
            result.ShouldBeOfType<Result<Unit>>();
            result.Success.ShouldBeTrue();

            var rates = await _mockRepo.Object.RateRepository.GetAll();
            rates.Count().ShouldBe(1);
        }

        [Fact]
        public async Task Delete_Rate_Doesnt_Exist()
        {

            _id  = 0;
            var result = await _handler.Handle(new DeleteRateCommand() { Id = _id }, CancellationToken.None);
            result.ShouldBe(null);
        
            var rates = await _mockRepo.Object.RateRepository.GetAll();
            rates.Count.ShouldBe(2);

        }
    }
}



