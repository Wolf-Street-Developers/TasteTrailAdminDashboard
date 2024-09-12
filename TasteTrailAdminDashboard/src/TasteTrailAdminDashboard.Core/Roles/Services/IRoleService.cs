
using TasteTrailData.Core.Roles.Enums;
using TasteTrailAdminDashboard.Core.Roles.Models;

namespace TasteTrailAdminDashboard.Core.Roles.Services;

public interface IRoleService
{
    Task<Role> GetRoleAsNoTrackingAsync(string id);

    Task<Role> GetRoleByIdAsync(string id);

    Task CreateRoleAsync(UserRoles role);

    Task DeleteRoleAsync(UserRoles role);

    Task SetupRolesAsync();

    Task<bool> RoleExistsAsync(UserRoles role);

    Task<Role> GetByNameAsync(UserRoles userRole);
}

