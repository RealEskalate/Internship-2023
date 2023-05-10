using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Application.Features._Tags.DTOs.Validators
{
    public class createTagDtoValidator : AbstractValidator<createTagDto>
    {
        public createTagDtoValidator()
        {
            Include(new I_TagDtoValidator());
        }
    }
}
