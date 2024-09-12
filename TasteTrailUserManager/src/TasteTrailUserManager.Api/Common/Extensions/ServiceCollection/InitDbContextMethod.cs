using Microsoft.EntityFrameworkCore;
using TasteTrailUserManager.Infrastructure.Common.Data;

namespace TasteTrailUserManager.Api.Common.Extensions.ServiceCollection;

public static class InitDbContextMethod
{
    public static void InitDbContext(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection.AddDbContext<TasteTrailUserManagerDbContext>(options =>
        {
            var connectionString = configuration.GetConnectionString("SqlConnection") ?? throw new SystemException("connectionString is not set");
            options.UseNpgsql(connectionString);
        });
    }
}


