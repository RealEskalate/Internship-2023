using AutoMapper;
using CineFlex.Application.Contracts.Persistence;
using CineFlex.Application.Features.Book.CQRS.Commands;
using CineFlex.Application.Features.Book.DTO.Validators;
using CineFlex.Application.Responses;
using CineFlex.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Threading;



namespace CineFlex.Application.Features.Book.CQRS.Handlers
{
    public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, BaseCommandResponse<int>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CreateBookCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseCommandResponse<int>> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse<int>();
            var validator = new CreateBookDtoValidator();
            var validationResult = await validator.ValidateAsync(request.BookDto);
            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();

            }
            else
            {
                var book = _mapper.Map<Domain.Book>(request.BookDto);

                book = await _unitOfWork.BookRepository.Add(book);

                if (await _unitOfWork.Save() > 0)
                {
                    response.Success = true;
                    response.Message = "Creation Successfull";
                    response.Value = book.Id;
                }
                else
                {
                    response.Success = false;
                    response.Message = "Creation Failed";

                }

            }
            return response;
        }

    }
}


