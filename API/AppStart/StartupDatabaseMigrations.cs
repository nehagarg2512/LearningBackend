using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Persistence;
using Persistence.Context;
using Serilog;
using System;

namespace API.AppStart
{
    public static class StartupDatabaseMigrations
    {
        public static void Configuration(IServiceProvider serviceProvider, ILogger logger)
        {
            try
            {
                logger.Information("Run EFCore migrations, if any");
                using IServiceScope scope = serviceProvider.CreateScope();
                serviceProvider = scope.ServiceProvider;
                DataContext context = serviceProvider.GetRequiredService<DataContext>();
                context.Database.Migrate();
                logger.Information("EFCore migrations completed");

                Seed.SeedData(context);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "An error occured during migration");
            }
        }
    }
}
