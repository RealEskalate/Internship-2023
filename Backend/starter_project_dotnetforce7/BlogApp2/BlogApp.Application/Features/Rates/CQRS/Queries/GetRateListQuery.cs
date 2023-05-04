using BlogApp.Application.Features._Indices.DTOs;
using BlogApp.Application.Features.Rates.DTOs;
using BlogApp.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Application.Features.Rates.CQRS.Queries
{
    public class GetRateListQuery: IRequest<Result<List<RateDto>>>
    {
    }
}
