using BlogApp.Application.Contracts.Persistence;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Application.Features.Rates.DTOs.Validators
{
    public class CreateRateDtoValidator : AbstractValidator<CreateRateDto>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateRateDtoValidator(IUnitOfWork UnitOfWork)
        {
            _unitOfWork = UnitOfWork;
            Include(new IRateDtoValidator(_unitOfWork));
        }
    }

}
