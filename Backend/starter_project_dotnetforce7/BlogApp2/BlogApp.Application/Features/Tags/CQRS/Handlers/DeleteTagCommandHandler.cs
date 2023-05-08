using AutoMapper;
using BlogApp.Application.Contracts.Persistence;
using BlogApp.Application.Exceptions;
using BlogApp.Application.Features.Tags.CQRS.Commands;
using BlogApp.Application.Responses;
using MediatR;

namespace BlogApp.Application.Features.Tags.CQRS.Handlers
{
    public class DeleteTagCommandHandler : IRequestHandler<DeleteTagCommand, Result<Unit>>
    {


        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteTagCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;

        }

        public async Task<Result<Unit>> Handle(DeleteTagCommand request, CancellationToken cancellationToken)
        {
            var response = new Result<Unit>();
            var tag = await _unitOfWork.TagRepository.Get(request.Id);

            if (tag == null) {
                Console.WriteLine(tag);
                return null; }
                


           await _unitOfWork.TagRepository.Delete(tag);

           if( await _unitOfWork.Save() > 0 )
            {
                response.Success = true;
                response.Message = "Delete Successful";
            }
            else
            {
                response.Success = false;
                response.Message = "Delete Failded";
            }

            return response;

        }
    }





}