using AutoMapper;
using BlogApp.Application.Contracts.Persistence;
using BlogApp.Application.Features.BlogRates.CQRS.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Application.Features.BlogRates.CQRS.Handlers
{
    public class UpdateBlogRateCommandHandler : IRequestHandler<UpdateBlogRateCommand, Unit>
    {
        private readonly IBlogRateRepository _blogRateRepository;
        private readonly IMapper _mapper;
        public UpdateBlogRateCommandHandler(IBlogRateRepository blogRateRepository, IMapper mapper)
        {
            _blogRateRepository = blogRateRepository;
            _mapper = mapper;
            
        }
        public async Task<Unit> Handle(UpdateBlogRateCommand request, CancellationToken cancellationToken)
        {
            var blogRate = await _blogRateRepository.Get(request.BlogRateDto.Id);
            _mapper.Map(request.BlogRateDto, blogRate);
            await _blogRateRepository.Update(blogRate);
            return Unit.Value;
        }
    }
}
