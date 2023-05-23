// using MediatR;
// using AutoMapper;
// using CineFlex.Domain;
// using CineFlex.Application.Responses;
// using CineFlex.Application.Features.Seats.DTOs;
// using CineFlex.Application.Contracts.Persistence;
// using CineFlex.Application.Features.Seats.CQRS.Queries;

// namespace CineFlex.Application.Features.Seats.CQRS.Handlers
// {
//     public class GetCinemaSeatsQueryHandler : IRequestHandler<GetCinemaSeatsQuery, BaseCommandResponse<List<SeatListDto>>>
//     {
//         private readonly IMapper _mapper;
//         private readonly IUnitOfWork _unitOfWork;

//         public GetCinemaSeatsQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
//         {
//             _mapper = mapper;
//             _unitOfWork = unitOfWork;
//         }

//         public async Task<BaseCommandResponse<List<SeatListDto>>> Handle(GetCinemaSeatsQuery request, CancellationToken cancellationToken)
//         {
//             List<Seat> seats = await _unitOfWork.SeatRepository.GetSeatsByCinemaID(request.CinemaID);
            
//             return new BaseCommandResponse<List<SeatListDto>>{
//                 Success=true,
//                 Value=_mapper.Map<List<SeatListDto>>(seats)
//             };
//         }
//     }
// }