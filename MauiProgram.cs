using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;

namespace NailBar_App
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder.UseMauiApp<App>().ConfigureFonts(fonts =>
            {
                fonts.AddFont("Poppins-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("Poppins-SemiBold.ttf", "OpenSansSemibold");
            }).UseMauiCommunityToolkit();
#if DEBUG
            builder.Logging.AddDebug();
#endif
            return builder.Build();
        }
    }
}