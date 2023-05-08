using BlogApp.Application.Features._Indices.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Application.Features._Indices.DTOs.Validators
{
    public class Create_IndexDtoValidator : AbstractValidator<Create_IndexDto>
    {
        public Create_IndexDtoValidator()
        {
            Include(new I_IndexDtoValidator());
        }
    }

}
