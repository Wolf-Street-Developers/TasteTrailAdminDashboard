
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using TasteTrailAdminDashboard.Core.Roles.Models;
using TasteTrailAdminDashboard.Core.Roles.Repositories;
using TasteTrailAdminDashboard.Infrastructure.Common.BackgroundServices.Base;
using TasteTrailAdminDashboard.Infrastructure.Common.Options;
using TasteTrailData.Core.Roles.Enums;

namespace TasteTrailAdminDashboard.Infrastructure.Common.BackgroundServices;

public class RoleRabbitMqService : BaseRabbitMqService, IHostedService
{
    public RoleRabbitMqService(IOptions<RabbitMqOptions> optionsSnapshot, IServiceScopeFactory serviceScopeFactory) :
        base(optionsSnapshot, serviceScopeFactory)
    {
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        // base.StartListening("role_create_admin", async message => {
        //     using (var scope = base.serviceScopeFactory.CreateScope())
        //     {
        //         var roleRepository = scope.ServiceProvider.GetRequiredService<IRoleRepository>();

        //         var newRole = JsonSerializer.Deserialize<Role>(message)!;

        //         var foundRole = await roleRepository.GetByIdAsync(newRole.Id);

        //         if(foundRole is null)
        //         {
        //             await roleRepository.CreateAsync(newRole);
        //         }

        //         var roleEnum = Enum.Parse<UserRoles>(newRole.Name);
        //         var foudByNameRole = await roleRepository.GetByNameAsync(roleEnum);

        //         if(foudByNameRole is not null)
        //         {
        //             roleRepository.DeleteByIdAsync
        //         }
                
        //     }
        // });


        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}
