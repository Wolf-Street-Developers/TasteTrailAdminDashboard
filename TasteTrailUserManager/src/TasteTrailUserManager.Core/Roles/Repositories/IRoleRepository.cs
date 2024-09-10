using TasteTrailData.Core.Common.Repositories.Base;
using TasteTrailData.Core.Roles.Enums;
using TasteTrailUserManager.Core.Roles.Models;

namespace TasteTrailUserManager.Core.Roles.Repositories;

public interface IRoleRepository : IGetAsNoTrackingAsync<Role, string>, IGetByIdAsync<Role, string>
{
    Task<string> CreateRoleAsync(UserRoles role);

    Task<string> DeleteRoleAsync(UserRoles role);

    Task SetupRolesAsync();
}
