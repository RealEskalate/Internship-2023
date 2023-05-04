using AutoMapper;
using BlogApp.Application.Contracts.Persistence;
using BlogApp.Application.Features.Blogs.CQRS.Queries;
using BlogApp.Application.Features.Blogs.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Application.Features.Blogs.CQRS.Handlers
{
    public class GetBlogListQueryHandler : IRequestHandler<GetBlogListQuery, List<BlogDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetBlogListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<BlogDto>> Handle(GetBlogListQuery request, CancellationToken cancellationToken)
        {
            var _Indices = await _unitOfWork.BlogRepository.GetAll();
            Console.Write(_Indices);
            return _mapper.Map<List<BlogDto>>(_Indices);
        }
    }
}
