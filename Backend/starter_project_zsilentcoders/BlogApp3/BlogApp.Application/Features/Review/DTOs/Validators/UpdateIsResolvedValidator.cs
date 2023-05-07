using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Application.Features.Review.DTOs.Validators
{
    public class UpdateIsResolvedValidator: AbstractValidator<ReviewIsApprovedDto>
    {
        public UpdateIsResolvedValidator()
        {
            RuleFor(p => p.IsApproved).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
