using CineFlex.Domain;

namespace CineFlex.Application.Contracts.Persistence
{
    public interface IUserAccessor
    {
        string GetUsername();

        Task<AppUser> GetCurrentUser();

    }
}