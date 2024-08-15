using Application.Contracts;
using Microsoft.AspNetCore.Http;
namespace Infrastructure.Services;

public class UploadImagesService : IUploadImage
{
    public string SavePlatformImage(IFormFile imageFile, string name)
    {
        var serverBasePath = Path.Combine(Directory.GetCurrentDirectory());
        var directoryPath = Path.Combine(serverBasePath, "wwwroot", "images", "platforms");
        if (!Directory.Exists(directoryPath))
        {
            Directory.CreateDirectory(directoryPath);
        }
        var uniqueFileName = $"{Guid.NewGuid()}_{name}{Path.GetExtension(imageFile.FileName)}";
        var filePath = Path.Combine("wwwroot/images/platforms", uniqueFileName);
        using (var stream = new FileStream(filePath, FileMode.Create))
        {
            imageFile.CopyTo(stream);
        }
        return $"/images/platforms/{uniqueFileName}";
    }
}