using CineFlex.Application.Features.Books.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Application.Features.Books.CQRS.Queries;
public class GetBookListQuery : IRequest<List<BookDto>>
{
}
