using MauiStoresApp.ViewModels;
using MauiStoresApp.Views;
using StoresApiClient.RestServices;

namespace MauiStoresApp
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

            builder.Services.AddTransient<MainPage>()
                .AddTransient<MainViewModel>()
                .AddSingleton<BranchRestService>(); 

            builder.Services.AddHttpClient<BranchRestService>(client => client.BaseAddress = new ("https://8ed0-186-112-123-43.ngrok.io/branches"));

            return builder.Build();
        }
    }
}