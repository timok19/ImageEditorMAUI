using Microsoft.AspNetCore.Components.Forms;

namespace ImageEditorMAUI.Data.Infrastructure;

public interface IImageConverterService
{
    Task<string> ConvertToImageURL(IBrowserFile file);
}