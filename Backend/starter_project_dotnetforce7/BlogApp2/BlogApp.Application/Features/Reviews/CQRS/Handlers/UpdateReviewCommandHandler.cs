using AutoMapper;
using BlogApp.Application.Contracts.Persistence;
using BlogApp.Application.Exceptions;
using BlogApp.Application.Features.Reviews.CQRS.Commands;
using BlogApp.Application.Features.Reviews.DTOs.Validators;
using BlogApp.Application.Responses;
using MediatR;


namespace BlogApp.Application.Features.Reviews.CQRS.Handlers
{
    public class UpdateReviewCommandHandler : IRequestHandler<UpdateReviewCommand, Result<Unit>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateReviewCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<Unit>> Handle(UpdateReviewCommand request, CancellationToken cancellationToken)
        {
            var response = new Result<Unit>();

            var validator = new UpdateReviewDtoValidator();
            var validationResult = await validator.ValidateAsync(request.ReviewDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Update Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var review = await _unitOfWork.ReviewRepository.Get(request.ReviewDto.Id);

                if (review is null)
                    return null;
                   
                _mapper.Map(request.ReviewDto, review);

                await _unitOfWork.ReviewRepository.Update(review);
              
                if (await _unitOfWork.Save() > 0)
                {
                    response.Success = true;
                    response.Message = "Updated Successful";
                }
                else
                {
                    response.Success = false;
                    response.Message = "Update Failed";
                }    
            }

            return response;
        }
    }
}
