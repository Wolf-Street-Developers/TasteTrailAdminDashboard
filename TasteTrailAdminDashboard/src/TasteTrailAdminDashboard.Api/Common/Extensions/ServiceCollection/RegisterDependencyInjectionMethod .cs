
using TasteTrailAdminDashboard.Core.Common.Admin.Services;
using TasteTrailAdminDashboard.Core.Common.Services;
using TasteTrailAdminDashboard.Core.Roles.Repositories;
using TasteTrailAdminDashboard.Core.Roles.Services;
using TasteTrailAdminDashboard.Core.Users.Repositories;
using TasteTrailAdminDashboard.Core.Users.Services;
using TasteTrailAdminDashboard.Infrastructure.Common.Admin.Services;
using TasteTrailAdminDashboard.Infrastructure.Common.BackgroundServices;
using TasteTrailAdminDashboard.Infrastructure.Common.Services;
using TasteTrailAdminDashboard.Infrastructure.Roles.Repositories;
using TasteTrailAdminDashboard.Infrastructure.Roles.Services;
using TasteTrailAdminDashboard.Infrastructure.Users.Repositories;
using TasteTrailAdminDashboard.Infrastructure.Users.Services;

namespace TasteTrailAdminDashboard.Api.Common.Extensions.ServiceCollection;

public static class RegisterDependencyInjectionMethod 
{
    public static void RegisterDependencyInjection(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddTransient<IUserService, UserService>();
        serviceCollection.AddTransient<IRoleService, RoleService>();

        serviceCollection.AddTransient<IUserRepository, UserRepository>();
        serviceCollection.AddTransient<IRoleRepository, RoleRepository>();

        serviceCollection.AddTransient<IAdminService, AdminService>();

        serviceCollection.AddTransient<IMessageBrokerService, RabbitMqService>();

        serviceCollection.AddHostedService<UserRabbitMqService>();
        //serviceCollection.AddHostedService<RoleRabbitMqService>();

    } 
}
