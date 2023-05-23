using CineFlex.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Application.Features.Book.CQRS.Commands
{
    public class DeleteBookCommand : IRequest<BaseCommandResponse<Unit>>
    {
        public int Id { get; set; }
    }
}
