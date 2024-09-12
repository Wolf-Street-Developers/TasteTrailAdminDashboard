using Microsoft.EntityFrameworkCore;
using TasteTrailAdminDashboard.Infrastructure.Common.Data;

namespace TasteTrailAdminDashboard.Api.Common.Extensions.ServiceCollection;

public static class InitDbContextMethod
{
    public static void InitDbContext(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection.AddDbContext<TasteTrailAdminDashboardDbContext>(options =>
        {
            var connectionString = configuration.GetConnectionString("SqlConnection") ?? throw new SystemException("connectionString is not set");
            options.UseNpgsql(connectionString);
        });
    }
}


