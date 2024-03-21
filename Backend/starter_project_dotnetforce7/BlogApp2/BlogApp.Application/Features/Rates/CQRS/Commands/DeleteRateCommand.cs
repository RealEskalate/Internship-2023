using BlogApp.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Application.Features.Rates.CQRS.Commands
{
    public class DeleteRateCommand : IRequest<Result<Unit>>
    {
        public int Id { get; set; }
    }
}
