using BlogApp.Application.Features.Rates.DTOs;
using BlogApp.Application.Responses;
using MediatR;

namespace BlogApp.Application.Features.Rates.CQRS.Commands
{
    public class CreateRateCommand: IRequest<Result<int>>
    {
        public CreateRateDto RateDto { get; set; }
    }
}
