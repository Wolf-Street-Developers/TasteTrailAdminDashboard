
using System.Text.Json;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using TasteTrailAdminDashboard.Core.Users.Models;
using TasteTrailAdminDashboard.Core.Users.Repositories;
using TasteTrailAdminDashboard.Infrastructure.Common.BackgroundServices.Base;
using TasteTrailAdminDashboard.Infrastructure.Common.Dtos;
using TasteTrailAdminDashboard.Infrastructure.Common.Options;

namespace TasteTrailAdminDashboard.Infrastructure.Common.BackgroundServices;

public class UserRabbitMqService : BaseRabbitMqService, IHostedService
{
    public UserRabbitMqService(IOptions<RabbitMqOptions> optionsSnapshot, IServiceScopeFactory serviceScopeFactory) :
        base(optionsSnapshot, serviceScopeFactory)
    {
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        base.StartListening("user_create_admin", async message => {
            using (var scope = base.serviceScopeFactory.CreateScope())
            {
                var userRepository = scope.ServiceProvider.GetRequiredService<IUserRepository>();

                var newUser = JsonSerializer.Deserialize<User>(message)!;

                System.Console.WriteLine($"\n\n\n\n\n\n{newUser.UserName}\n\n\n\n\n\n\n\n");

                await userRepository.CreateAsync(newUser);
            }
        });

        base.StartListening("user_update_admin", async message => {

            using (var scope = base.serviceScopeFactory.CreateScope())
            {
                var userRepository = scope.ServiceProvider.GetRequiredService<IUserRepository>();

                var updateDto = JsonSerializer.Deserialize<UpdateUserSenderDto>(message)!;

                var userToUpdate = await userRepository.GetByIdAsync(updateDto.Id) ?? throw new ArgumentException($"there is no user with id: {updateDto.Id}");

                userToUpdate.Email = updateDto.Email is null ? userToUpdate.Email : updateDto.Email;
                userToUpdate.UserName = updateDto.UserName is null ? userToUpdate.UserName : updateDto.UserName;
                System.Console.WriteLine($"\n\n\n\n\n\n{updateDto.Id}   {updateDto.UserName}   {updateDto.Email}\n\n\n\n\n\n\n\n");
                await userRepository.PutAsync(userToUpdate);
            }
        });


        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}
