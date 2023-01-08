using Microsoft.AspNetCore.Components.Forms;

namespace ImageEditorMAUI.Data.Models;

public record ImageWithURL
{
    public IBrowserFile File { get; set; }
    public string ImageURL { get; set; }
}
