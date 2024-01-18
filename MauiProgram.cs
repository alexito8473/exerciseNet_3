using Microsoft.Extensions.Logging;
using UD4T3.Repositories;

namespace UD4T3 {
    public static class MauiProgram {
        public static MauiApp CreateMauiApp() {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts => {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Services.AddSingleton<AlumnoRepository>(); // Creamos un síngenton con la clase repositorio, esto es para que solo exista 1 base de datos.
#endif

            return builder.Build();
        }
    }
}
