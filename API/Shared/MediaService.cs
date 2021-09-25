using System.Threading.Tasks;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace API.Shared
{
    public class MediaService : IMediaService
    {
        private readonly Cloudinary _cloudinary;
        public MediaService(IOptions<CloudinarySetting> config){
            var acc = new Account(
                config.Value.CloudName,
                config.Value.APIKey,
                config.Value.APISecret
            );
         _cloudinary = new Cloudinary(acc);
        }
        public async Task<ImageUploadResult> AddPhotoAsync(IFormFile file)
        {
            var imageUploadResult = new ImageUploadResult();
            // if (file.Length != 0)
            // {
                using var stream = file.OpenReadStream();
                var imageParam = new ImageUploadParams
                {
                    File = new FileDescription(file.FileName, stream),
                    Transformation = new Transformation().Width(500).Height(500).Crop("fill").Gravity("face")
                };
                imageUploadResult = await _cloudinary.UploadAsync(imageParam);
                return imageUploadResult;
            // }
        }

        public Task<DeletionResult> DeletePhotoAsync(string PublicId)
        {
            var deleteParams = new DeletionParams(PublicId);
            var result = _cloudinary.DestroyAsync(deleteParams);
            return result;
        }
    }

    public interface IMediaService
    {
        Task<ImageUploadResult> AddPhotoAsync(IFormFile file);
 Task<DeletionResult> DeletePhotoAsync(string PublicId);

    }
}