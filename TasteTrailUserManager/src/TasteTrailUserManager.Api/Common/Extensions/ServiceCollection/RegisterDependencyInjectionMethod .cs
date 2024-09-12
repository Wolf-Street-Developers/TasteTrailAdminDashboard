
using TasteTrailUserManager.Core.Roles.Repositories;
using TasteTrailUserManager.Core.Roles.Services;
using TasteTrailUserManager.Core.Users.Repositories;
using TasteTrailUserManager.Core.Users.Services;
using TasteTrailUserManager.Infrastructure.Roles.Repositories;
using TasteTrailUserManager.Infrastructure.Roles.Services;
using TasteTrailUserManager.Infrastructure.Users.Repositories;
using TasteTrailUserManager.Infrastructure.Users.Services;

namespace TasteTrailUserManager.Api.Common.Extensions.ServiceCollection;

public static class RegisterDependencyInjectionMethod 
{
    public static void RegisterDependencyInjection(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddTransient<IUserService, UserService>();
        serviceCollection.AddTransient<IRoleService, RoleService>();

        serviceCollection.AddTransient<IUserRepository, UserRepository>();
        serviceCollection.AddTransient<IRoleRepository, RoleRepository>();

    } 
}
