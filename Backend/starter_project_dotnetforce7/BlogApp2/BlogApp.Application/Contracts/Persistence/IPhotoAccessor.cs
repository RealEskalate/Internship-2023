using BlogApp.Application.Responses;
using BlogApp.Domain;
using Microsoft.AspNetCore.Http;
// using System.Threading.Tasks;

namespace BlogApp.Application.Contracts.Persistence
{
    public interface IPhotoAccessor 
    {
        Task<Result<Photo>> AddPhoto(IFormFile file);

        Task<string> DeletePhoto(string publicId);

    }
}