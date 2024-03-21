using BlogApp.Application.Contracts.Persistence;
using BlogApp.Application.Features._Indices.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Application.Features.Rates.DTOs.Validators
{
    public class IRateDtoValidator : AbstractValidator<IRateDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        public IRateDtoValidator(IUnitOfWork UnitOfWork)
        {
            _unitOfWork = UnitOfWork;

            RuleFor(p => p.RaterId)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();

            RuleFor(p => p.RateNo)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .GreaterThan(0).WithMessage("{PropertyName} must be greater than or equal to {ComparisonValue}.")
                .LessThanOrEqualTo(5).WithMessage("{PropertyName} must not exceed {ComparisonValue}.");
            
            RuleFor(p => p.BlogId)
                .GreaterThan(0)
                .MustAsync(async (id, token) => {
                    return  await _unitOfWork.BlogRepository.Exists(id);
                })
                .WithMessage("{PropertyName} does't exist");
        }
    }
}
