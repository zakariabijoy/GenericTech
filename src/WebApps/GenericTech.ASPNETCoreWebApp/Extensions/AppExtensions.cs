using GenericTech.ASPNETCoreWebApp.Data;

namespace GenericTech.ASPNETCoreWebApp.Extensions;

public static class AppExtensions
{
    public static WebApplication SeedDatabase(this WebApplication application)
    {
        using (var scope = application.Services.CreateScope())
        {
            var services = scope.ServiceProvider;
            var loggerFactory = services.GetRequiredService<ILoggerFactory>();

            try
            {
                var dbContext = services.GetRequiredService<ApplicationDbContext>();
                ContextSeed.SeedAsync(dbContext, loggerFactory).Wait();
            }
            catch (Exception exception)
            {
                var logger = loggerFactory.CreateLogger<Program>();
                logger.LogError(exception, "An error occurred seeding the DB.");
            }
        }

        return application;
    }
}
