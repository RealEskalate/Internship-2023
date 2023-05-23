using CineFlex.Application.Features.Book.DTOs;
using CineFlex.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Application.Features.Book.CQRS.Queries
{
    public class GetBookListQuery: IRequest<BaseCommandResponse<List<BookDto>>>
    {
    }
}
