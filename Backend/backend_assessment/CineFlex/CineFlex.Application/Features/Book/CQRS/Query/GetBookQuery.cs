using CineFlex.Application.Features.Book.DTO;
using CineFlex.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Application.Features.Book.CQRS.Query
{
    public class GetBookQuery : IRequest<BaseCommandResponse<BookDto>>
    {
        public int Id { get; set; }
    }
}
