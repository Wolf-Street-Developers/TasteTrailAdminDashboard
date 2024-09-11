
using TasteTrailData.Core.Roles.Enums;
using TasteTrailUserManager.Core.Roles.Models;

namespace TasteTrailUserManager.Core.Roles.Services;

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

