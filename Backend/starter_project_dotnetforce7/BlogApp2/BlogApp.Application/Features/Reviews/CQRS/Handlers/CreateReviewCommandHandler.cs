using AutoMapper;
using BlogApp.Application.Contracts.Persistence;
using BlogApp.Application.Features.Reviews.CQRS.Commands;
using BlogApp.Application.Features.Reviews.DTOs.Validators;
using BlogApp.Application.Responses;
using MediatR;
using BlogApp.Domain;

namespace BlogApp.Application.Features.Reviews.CQRS.Handlers
{
    public class CreateReviewCommandHandler : IRequestHandler<CreateReviewCommand, Result<int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateReviewCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<int>> Handle(CreateReviewCommand request, CancellationToken cancellationToken)
        {
            var response = new Result<int>();
            var validator = new CreateReviewDtoValidator();
            var validationResult = await validator.ValidateAsync(request.ReviewDto);

            if (validationResult.IsValid == false) 
            {
                response.Success = false;
                response.Message = "Validation Error";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var review = _mapper.Map<Review>(request.ReviewDto);

                review = await _unitOfWork.ReviewRepository.Add(review);
                if (await _unitOfWork.Save() > 0)
                {
                    response.Success = true;
                    response.Message = "Creation Successful";
                    response.Value = review.Id;
                }
                else
                {
                    response.Success = false;
                    response.Message = "Creation Failed";
                }
            }

            return response;
        }
    }
}
