using Microsoft.Extensions.Logging;
using ImageEditorMAUI.Data;
using ImageEditorMAUI.Data.Infrastructure;
using MudBlazor.Services;

namespace ImageEditorMAUI;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
            });

        builder.Services.AddMudServices();
        builder.Services.AddMauiBlazorWebView();

#if DEBUG
        builder.Services.AddBlazorWebViewDeveloperTools();
        builder.Logging.AddDebug();
#endif
        builder.Services.AddScoped<IImageConverterService, ImageConverterService>();
        builder.Services.AddMudServices();

        return builder.Build();
    }
}