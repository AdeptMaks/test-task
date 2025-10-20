using Api.Data;
using Microsoft.EntityFrameworkCore;

namespace Api.Configurations;

public static class MigrationExtensions
{
    public static WebApplication MigrateDatabase(this WebApplication webApp)
    {
        using (var scope = webApp.Services.CreateScope())
        {
            var services = scope.ServiceProvider;
            try
            {
                var db = services.GetRequiredService<ApplicationDbContext>();
                db.Database.Migrate();
            }
            catch (Exception ex)
            {
                var logger = services.GetRequiredService<ILogger<Program>>();
                logger.LogError(ex, "An error occurred during database migration.");
            }
        }
        return webApp;
    }
}
