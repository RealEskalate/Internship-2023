using BlogApp.Application.Contracts.Persistence;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Application.Features.Review.DTOs.Validators
{
    public class DeleteReviewValidator: AbstractValidator<int>
    {

        public DeleteReviewValidator(IUnitOfWork _unitOfWork)
        {
            RuleFor(id=>id)
                .MustAsync(async (id, token) => await _unitOfWork.ReviewRepository.Exists(id))
                .WithMessage("Review with given {ProperyName} not found.");
        }
        
    }
}
