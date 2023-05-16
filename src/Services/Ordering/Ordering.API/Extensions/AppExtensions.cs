using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Ordering.API.Extensions;

public static  class AppExtensions
{
  public static WebApplication MigrateDatabase<TContext>(this WebApplication application,
                                                  Action<TContext, IServiceProvider> seeder,
                                                  int? retry = 0) where TContext : DbContext
  {
        int retryForAvailability = retry.Value;

        using (var scope = application.Services.CreateScope())
        {
            var services = scope.ServiceProvider;
            var logger =  services.GetRequiredService<ILogger<TContext>>();
            var context = services.GetRequiredService<TContext>();

            try
            {
                logger.LogInformation("Migrating database associated with context {DbContextName}", typeof(TContext).Name);

                InvokeSeeder(seeder, context, services);

                logger.LogInformation("Migrated database associated with context {DbContextName}", typeof(TContext).Name);
            }
            catch (SqlException sqlEx)
            {

                logger.LogError(sqlEx,"An error occurred while migrating the databsae used on context {DbContextName}", typeof(TContext).Name);

                if(retryForAvailability < 50) 
                {
                    retryForAvailability++;
                    Thread.Sleep(2000);
                    MigrateDatabase<TContext>(application, seeder, retryForAvailability);   
                }
            }
        }
        return application; 
  }

    private static void InvokeSeeder<TContext>(Action<TContext, IServiceProvider> seeder,
                                                TContext context,
                                                IServiceProvider services) where TContext : DbContext
    {
       context.Database.Migrate();
       seeder(context,services);
    }
}
