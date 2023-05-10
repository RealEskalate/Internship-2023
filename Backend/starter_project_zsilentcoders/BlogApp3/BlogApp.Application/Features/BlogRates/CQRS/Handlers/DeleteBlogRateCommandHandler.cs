using AutoMapper;
using BlogApp.Application.Contracts.Persistence;
using BlogApp.Application.Features.BlogRates.CQRS.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Application.Features.BlogRates.CQRS.Handlers
{
    public class DeleteBlogRateCommandHandler : IRequestHandler<DeleteBlogRateCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public DeleteBlogRateCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            
        }
        public async Task<Unit> Handle(DeleteBlogRateCommand request, CancellationToken cancellationToken)
        {
            var blogRate = await _unitOfWork.BlogRateRepository.Get(request.Id);
            await _unitOfWork.BlogRateRepository.Delete(blogRate);

            return Unit.Value;
                
            
        }
    }
}
