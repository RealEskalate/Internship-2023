using BlogApp.Application.Contracts.Persistence;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Application.Features.BlogRates.DTOs.Validators
{
    public class CreateBlogRateDtoValidator : AbstractValidator<CreateBlogRateDto>
    {
        public CreateBlogRateDtoValidator(IUnitOfWork unitOfWork)
        {
            //RuleFor(p => p.RaterId).GreaterThan(0).WithMessage("{PropertyName} invalid user")
            //.MustAsync(async (id, token) => await unitOfWork.UserRepository.UserExists(id)).WithMessage($"User not found"););

            RuleFor(p => p.BlogId).GreaterThan(0).WithMessage("{PropertyName} have invalid value")
                .MustAsync(async (id, token) => await unitOfWork.BlogRepository.Exists(id)).WithMessage($"Blog not found");

            RuleFor(p => p.RateNo).GreaterThan(0).LessThan(6).WithMessage("{PropertyName} have invalid value");

        }
    }
}
