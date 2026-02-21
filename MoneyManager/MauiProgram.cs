using Microsoft.Extensions.Logging;
using MoneyManager.Data;
using CommunityToolkit.Maui;

namespace MoneyManager
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()  // basic maui app
                .UseMauiCommunityToolkit() // reg com tool kit
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            builder.Services.AddDbContext<AppDbContext>(); // register DbContext to DI

            builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>)); // generical register Repository for DI

            var app = builder.Build();
            InitDatabase(app);

    		// builder.Logging.AddDebug(); dont know for now
            return app;
        }

        private static void InitDatabase(MauiApp app)
        {
            using var scope = app.Services.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            db.Database.EnsureCreated(); // create database, if not created yet
        }
    }
}
