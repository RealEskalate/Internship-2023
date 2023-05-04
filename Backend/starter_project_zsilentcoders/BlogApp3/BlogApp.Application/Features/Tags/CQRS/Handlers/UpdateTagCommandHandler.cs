using AutoMapper;
using BlogApp.Application.Contracts.Persistence;
using BlogApp.Application.Exceptions;
using BlogApp.Application.Features.Tags.CQRS.Commands;
using BlogApp.Application.Features.Tags.DTOs.Validators;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Application.Features.Tags.CQRS.Handlers
{
    public class UpdateTagCommandHandler : IRequestHandler<UpdateTagCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateTagCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateTagCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateTagDtoValidator();
            var validationResult = await validator.ValidateAsync(request.TagDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var Tag = await _unitOfWork.TagRepository.Get(request.TagDto.Id);

            if (Tag is null)
                throw new NotFoundException(nameof(Tag), request.TagDto.Id);

            _mapper.Map(request.TagDto, Tag);

            await _unitOfWork.TagRepository.Update(Tag);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
