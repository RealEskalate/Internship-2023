using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Application.Features._Tags.DTOs.Validators
{
    public class Create_TagDtoValidator : AbstractValidator<Create_TagDto>
    {
        public Create_TagDtoValidator()
        {
            Include(new I_TagDtoValidator());
        }
    }
}
