using CineFlex.Application.Contracts.Persistence;
using CineFlex.Domain;
using CineFlex.Domain.Common;

namespace CineFlex.Application.Services
{
    public class BookService
    {
        private readonly IMovieRepository _movieRepository;
        private readonly ISeatRepository _seatRepository;
        private readonly ICinemaRepository _cinemaRepository;

        public BookService(IMovieRepository movieRepository, ISeatRepository seatRepository, ICinemaRepository cinemaRepository)
        {
            _movieRepository = movieRepository;
            _seatRepository = seatRepository;
            _cinemaRepository = cinemaRepository;
        }

        public async Task<bool> CanCreateBook(int movieId, int seatId, int cinemaId)
        {
            bool movieExists = await _movieRepository.Exists(movieId);
            bool seatExists = await _seatRepository.Exists(seatId);
            bool cinemaExists = await _cinemaRepository.Exists(cinemaId);

            return movieExists && seatExists && cinemaExists;
        }
        public async Task<bool> IsSeatAvailable(int seatId)
        {

            Seat seatExists = await _seatRepository.Get(seatId);

            return seatExists.Available;
        }

    }
}
