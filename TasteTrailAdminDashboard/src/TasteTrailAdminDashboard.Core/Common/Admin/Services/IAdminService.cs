using TasteTrailData.Core.Roles.Enums;
using TasteTrailData.Infrastructure.Filters.Dtos;
using TasteTrailAdminDashboard.Core.Users.Dtos;
using TasteTrailAdminDashboard.Core.Users.Models;

namespace TasteTrailAdminDashboard.Core.Common.Admin.Services;

public interface IAdminService
{
    Task AssignRoleToUserAsync(string userId, UserRoles role);

    Task<FilterResponseDto<UserResponseDto>> GetUsersFiltereBySearchdAsync(FilterParametersSearchDto filterParameters);

    Task<User> GetUserByUsernameAsync(string username);

    Task<string> GetRoleByUsernameAsync(string username);

    Task<User> GetUserByIdAsync(string userId);

    Task<int> GetCountFilteredAsync(FilterParametersDto filterParameters);

    Task RemoveRoleFromUserAsync(string userId, UserRoles role);

    Task ToggleBanUserAsync(string userId);

    Task ToggleMuteUserAsync(string userId);
}
