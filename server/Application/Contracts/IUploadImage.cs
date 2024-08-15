
using Microsoft.AspNetCore.Http;

namespace Application.Contracts;
public interface IUploadImage
{
    string SavePlatformImage(IFormFile imageFile, string name);
}