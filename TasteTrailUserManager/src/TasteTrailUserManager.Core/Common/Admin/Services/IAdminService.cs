using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using TasteTrailData.Core.Roles.Enums;
using TasteTrailData.Infrastructure.Filters.Dtos;
using TasteTrailUserManager.Core.Users.Dtos;
using TasteTrailUserManager.Core.Users.Models;

namespace TasteTrailUserManager.Core.Common.Admin.Services;

public interface IAdminService
{
    Task<IdentityResult> AssignRoleToUserAsync(string userId, UserRoles role);

    Task<FilterResponseDto<UserResponseDto>> GetUsersFiltereBySearchdAsync(FilterParametersSearchDto filterParameters);

    Task<User> GetUserByUsernameAsync(string username);

    Task<IEnumerable<string>> GetRolesByUsernameAsync(string username);

    Task<User> GetUserByIdAsync(string userId);

    Task<int> GetCountFilteredAsync(FilterParametersDto filterParameters);

    Task<IdentityResult> RemoveRoleFromUserAsync(string userId, UserRoles role);

    Task<IdentityResult> ToggleBanUserAsync(string userId);

    Task<IdentityResult> ToggleMuteUserAsync(string userId);
}
