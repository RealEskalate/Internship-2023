using BlogApp.Application.Contracts.Persistence;
using BlogApp.Application.Features.Blogs.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Application.Features.Blogs.DTOs.Validators

{
    public class CreateBlogDtoValidator : AbstractValidator<CreateBlogDto>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateBlogDtoValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            Include(new IBlogDtoValidator());

            RuleFor(b => b.BlogTags)
          .CustomAsync(async (tags, context, cancellationToken) =>
          {

              if (tags == null)
                  return;

        
              var tagIds = tags.ToArray(); // Convert to array for easier iteration

              foreach (var id in tagIds)
              {
                  if (!await _unitOfWork.TagRepository.Exists(id) || id == 0)
                  {
                      context.AddFailure($"Tag with ID {id} does not exist.");
                  }
              }
          });

        }
    }

}
