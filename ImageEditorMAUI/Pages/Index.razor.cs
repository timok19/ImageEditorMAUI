using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using ImageEditorMAUI.Data.Infrastructure;
using ImageEditorMAUI.Data.Models;

namespace ImageEditorMAUI.Pages;

public partial class Index
{    
    [Inject]
    public IImageConverterService ImageConverterService { get; set; }

    private static List<ImageWithURL> Images { get; set; } = new();
    private bool IsChecked { get; set; } = false;
    private ImageWithURL ImageWithUrl { get; set; }

    private async Task UploadFiles(IReadOnlyList<IBrowserFile> files)
    {
        foreach (var file in files)
        {
            ImageWithUrl = new ImageWithURL
            {
                File = file,
                ImageURL = await ImageConverterService.ConvertToImageURL(file)
            };
            Images.Add(ImageWithUrl);
        }
    }

    //private async Task<bool> DeleteFiles(List<ImageWithURL> files)
    //{
    //    foreach (var file in files)
    //    {
    //        if (IsChecked == false)
    //        {
    //            IsChecked = true;
    //            Images.Remove(file);
    //        }
    //        return IsChecked;
    //    }
    //}
}