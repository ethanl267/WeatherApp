using Microsoft.Extensions.Logging;
using WeatherApp.Services;
using WeatherApp.Models;
using WeatherApp.ViewModels;
using WeatherApp.Views;

namespace WeatherApp
{
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
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();

            builder.Services.AddTransient<WeatherDataApiService>();
            builder.Services.AddTransient<WeatherViewModel>();
            builder.Services.AddTransient<DisplayWeatherPage>();
#endif

            return builder.Build();
        }
    }
}
