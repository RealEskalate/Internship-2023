using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using BlogApp.Application.Contracts.Persistence;
using BlogApp.Domain;
using BlogApp.Application.Responses;

namespace Infrastructure.Photos
{
    public class PhotoAccessor : IPhotoAccessor
    {
        private readonly Cloudinary _cloudinary;

        public PhotoAccessor(IOptions<CloudinarySettings> config)
        {
           var account = new Account(
            config.Value.CloudName,
            config.Value.ApiKey,
            config.Value.ApiSecret
           );

           _cloudinary =  new Cloudinary(account);

        }
        public async Task<Result<Photo>> AddPhoto(IFormFile file)
        {
            var response = new Result<Photo>();

            if(file.Length > 0)
            {


                await using var stream = file.OpenReadStream();
                var uploadParams = new ImageUploadParams
                {
                  File = new FileDescription(file.FileName, stream),
                  Transformation = new Transformation().Height(500).Width(500).Crop("fill")  
                };

                var uploadResult = await _cloudinary.UploadAsync(uploadParams);
                if(uploadResult.Error != null){
                    response.Success = false;
                    response.Message = uploadResult.Error.Message;
                }
                else{
                        response.Success = true;
                        response.Value =  new Photo{
                        Id = uploadResult.PublicId,
                        Url = uploadResult.SecureUrl.ToString()
                    };
                }
             
            }
            return response;
        }

        public async Task<string> DeletePhoto(string publicId)
        {
            var deleteParams = new DeletionParams(publicId);
            var result = await _cloudinary.DestroyAsync(deleteParams);
            
            return result.Result == "ok" ? result.Result : null;
        }
    }
}