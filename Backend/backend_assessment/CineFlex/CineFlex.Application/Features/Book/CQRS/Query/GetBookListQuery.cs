using CineFlex.Application.Features.Book.DTO;
using CineFlex.Application.Responses;
using MediatR;

namespace CineFlex.Application.Features.Book.CQRS.Query
{
    public class GetBookListQuery : IRequest<BaseCommandResponse<List<BookDto>>>
    {

    }
}