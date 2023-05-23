using AutoMapper;
using CineFlex.Application.Contracts.Persistence;
using CineFlex.Application.Features.Book.CQRS.Commands;
using CineFlex.Application.Features.Book.DTO;
using CineFlex.Application.Features.Book.DTO.Validators;
using CineFlex.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Application.Features.Book.CQRS.Handlers
{
    public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand, BaseCommandResponse<Unit>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateBookCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse<Unit>> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse<Unit>();
            var validator = new UpdateBookDtoValidator();
            var validationResult = await validator.ValidateAsync(request.updateBookDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Update Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();

            }

            var Book = await _unitOfWork.BookRepository.Get(request.updateBookDto.Id);

            if (Book == null)
            {
                response.Success = true;
                response.Message = "no Book found by this id";
            }
            _mapper.Map(request.updateBookDto, Book);
            await _unitOfWork.BookRepository.Update(Book);
            if (await _unitOfWork.Save() > 0)
            {
                response.Success = true;
                response.Message = "Successfully Updated";
                response.Value = Unit.Value;
            }
            else
            {
                response.Success = false;
                response.Message = "Update Failed";
            }

            return response;
        }
    }
}
