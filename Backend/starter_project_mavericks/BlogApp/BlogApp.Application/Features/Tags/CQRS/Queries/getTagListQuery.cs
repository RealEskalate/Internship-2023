﻿using BlogApp.Application.Features.Tags.DTOs;
using BlogApp.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Application.Features.Tags.CQRS.Queries
{
    public class getTagListQuery: IRequest<BaseResponse<List<TagDto>>>
    {
    }
}
