﻿using AutoMapper;
using CineFlex.Application.Contracts.Persistence;
using CineFlex.Application.Exceptions;
using CineFlex.Application.Features.Books.DTO.Validator;
using CineFlex.Application.Features.Books.CQRS.Commands;
using CineFlex.Domain;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Application.Features.Books.CQRS.Handlers;
public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, int>
{
    private readonly IBookRepository _bookRepository;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public CreateBookCommandHandler(IBookRepository bookRepository, IMapper mapper, IHttpContextAccessor httpContextAccessor, IUnitOfWork unitOfWork)
    {
        _httpContextAccessor = httpContextAccessor;
        _bookRepository = bookRepository;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<int> Handle(CreateBookCommand request, CancellationToken cancellationToken)
    {
        var validator = new CreateBookDtoValidator(_unitOfWork);
        var validationResult = await validator.ValidateAsync(request.CreateBookDto, cancellationToken);

        if (validationResult.Errors.Count > 0)
            throw new ValidationException(validationResult);

        var book = _mapper.Map<Book>(request.CreateBookDto);
        book.ApplicationUserId = _httpContextAccessor.HttpContext.User.Claims
            .FirstOrDefault(q => q.Type == "uid")?.Value;
        foreach (var seatId in request.CreateBookDto.SeatIds)
        {
            book.Seats.Add(await _unitOfWork.SeatRepository.Get(seatId));
        }

        book = await _bookRepository.Add(book);

        return book.Id;
    }
}
