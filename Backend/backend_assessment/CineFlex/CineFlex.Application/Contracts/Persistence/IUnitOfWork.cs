namespace CineFlex.Application.Contracts.Persistence
{
    public interface IUnitOfWork : IDisposable
    {
        IMovieRepository MovieRepository { get; }
        ICinemaRepository CinemaRepository { get; }
        ISeatRepository SeatRepository { get; }
        IMovieBookingRepository MovieBookingRepository { get; }
        Task<int> Save();
    }
}