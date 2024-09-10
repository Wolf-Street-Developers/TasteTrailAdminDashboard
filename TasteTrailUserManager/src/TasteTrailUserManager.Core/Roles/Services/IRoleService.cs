
using TasteTrailData.Core.Roles.Enums;
using TasteTrailUserManager.Core.Roles.Models;

namespace TasteTrailUserManager.Core.Roles.Services;

public interface IRoleService
{
    Task<Role?> GetRoleAsNoTrackingAsync(string id);

    Task<Role?> GetRoleByIdAsync(string id);

    Task<Role> CreateRoleAsync(UserRoles role);

    Task<string> DeleteRoleAsync(UserRoles role);

    Task SetupRolesAsync();
}
