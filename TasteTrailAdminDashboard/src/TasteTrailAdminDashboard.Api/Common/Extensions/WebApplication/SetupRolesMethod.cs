namespace TasteTrailAdminDashboard.Api.Common.Extensions.WebApplication;

using Microsoft.AspNetCore.Builder;
using TasteTrailAdminDashboard.Core.Roles.Services;

public static class SetupRolesMethod
{
    public async static Task SetupRoles(this WebApplication app)
    {
        using (var scope = app.Services.CreateScope())
        {
            var roleService = scope.ServiceProvider.GetRequiredService<IRoleService>();
            await roleService.SetupRolesAsync();
        }
    }
}
