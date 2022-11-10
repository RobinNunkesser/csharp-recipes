using Microsoft.Extensions.DependencyInjection;

namespace DependencyInjection;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder.UseMauiApp<App>();
        builder.Services.AddSingleton<AppShell>();
        return builder.Build();
    }
}

