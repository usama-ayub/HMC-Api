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
        public MediaService(IOptions<CloudinarySetting> config)
        {
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

            using var stream = file.OpenReadStream();
            var imageParam = new ImageUploadParams
            {
                File = new FileDescription(file.FileName, stream),
                Transformation = new Transformation().Width(500).Height(500).Crop("fill").Gravity("face")
            };
            imageUploadResult = await _cloudinary.UploadAsync(imageParam);
            
            return imageUploadResult;
        }

        public async Task<ImageUploadResult> AddBase64PhotoAsync(string base64, string filename)
        {
            var imageUploadResult = new ImageUploadResult();
            // if (file.Length != 0)
            // {
            var imageParam = new ImageUploadParams
            {
                File = new FileDescription(filename, $"@{base64}"),
                Transformation = new Transformation().Width(500).Height(500).Crop("fill").Gravity("face")
            };
            imageUploadResult = await _cloudinary.UploadAsync(imageParam);
            return imageUploadResult;
            // }
        }

        public Task<DeletionResult> DeletePhotoAsync(string publicId)
        {
            var deleteParams = new DeletionParams(publicId);
            var result = _cloudinary.DestroyAsync(deleteParams);
            return result;
        }
    }

    public interface IMediaService
    {
        Task<ImageUploadResult> AddPhotoAsync(IFormFile file);
        Task<ImageUploadResult> AddBase64PhotoAsync(string base64, string filename);
        Task<DeletionResult> DeletePhotoAsync(string publicId);

    }
}