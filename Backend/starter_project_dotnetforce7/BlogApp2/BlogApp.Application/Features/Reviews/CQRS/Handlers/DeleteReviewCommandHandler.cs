using AutoMapper;
using BlogApp.Application.Contracts.Persistence;
using BlogApp.Application.Exceptions;
using BlogApp.Application.Features.Reviews.CQRS.Commands;
using BlogApp.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Application.Features.Reviews.CQRS.Handlers
{
    public class DeleteReviewCommandHandler : IRequestHandler<DeleteReviewCommand,Result<Unit>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteReviewCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<Unit>> Handle(DeleteReviewCommand request, CancellationToken cancellationToken)
        {
            var response = new Result<Unit>();
            var review = await _unitOfWork.ReviewRepository.Get(request.Id);

            if (review == null)
            {
                return null;
            }
            else
            {
                await _unitOfWork.ReviewRepository.Delete(review);
                if (await _unitOfWork.Save() > 0 )
                {
                    response.Success = true;
                    response.Message = "Delete Successful";
                }
                else
                {
                    response.Success = true;
                    response.Message = "Delete Failed";
                }
            
            }
            return response;
        }
    }
}
