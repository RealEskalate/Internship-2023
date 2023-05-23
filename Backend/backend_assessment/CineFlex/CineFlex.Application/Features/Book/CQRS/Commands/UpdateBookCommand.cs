using CineFlex.Application.Features.Books.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Application.Features.Books.CQRS.Commands;
public class UpdateBookCommand : IRequest
{
    public UpdateBookDto UpdateBookDto { get; set; }
}
