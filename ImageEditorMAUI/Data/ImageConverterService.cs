using ImageEditorMAUI.Data.Infrastructure;
using Microsoft.AspNetCore.Components.Forms;

namespace ImageEditorMAUI.Data;

public class ImageConverterService : IImageConverterService
{
    public async Task<string> ConvertToImageURL(IBrowserFile file)
    {
        var imageUrl = $"data:{file.ContentType};base64,";
        using var stream = new MemoryStream();
        
        var oprimizedImage = await file.RequestImageFileAsync(file.ContentType, 1280, 720);
        using var rs = oprimizedImage.OpenReadStream(oprimizedImage.Size);
        await rs.CopyToAsync(stream);
            
        var buffer = stream.ToArray();

        return imageUrl + Convert.ToBase64String(buffer);
    }
}