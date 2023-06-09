using BlogApp.Application.Features._Indices.DTOs;
using BlogApp.Application.Features.Comments.DTOs;
using BlogApp.Application.Features.Comments.DTOs;
using BlogApp.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Application.Features.Comments.CQRS.Queries
{
    public class GetCommentListQuery: IRequest<Result<List<CommentDto>>>
    {
    }
}
