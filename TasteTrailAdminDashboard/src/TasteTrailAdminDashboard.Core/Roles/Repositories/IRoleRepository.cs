using TasteTrailData.Core.Common.Repositories.Base;
using TasteTrailData.Core.Roles.Enums;
using TasteTrailAdminDashboard.Core.Roles.Models;

namespace TasteTrailAdminDashboard.Core.Roles.Repositories;

public interface IRoleRepository : IGetAsNoTrackingAsync<Role, string>, IGetByIdAsync<Role, string>, 
    ICreateAsync<Role, int>, IDeleteByIdAsync<string, int>, IPutAsync<Role, int>
{
    Task<Role?> GetByNameAsync(UserRoles role);

    Task<int> SetupRolesAsync();

    Task<bool> RoleExistsAsync(UserRoles role);
}
