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
    Task<string> AssignRoleToUserAsync(string userId, UserRoles role);

    Task<FilterResponseDto<UserResponseDto>> GetUsersFiltereBySearchdAsync(FilterParametersSearchDto filterParameters);

    Task<User> GetUserByUsernameAsync(string username);

    Task<string> GetRoleByUsernameAsync(string username);

    Task<User> GetUserByIdAsync(string userId);

    Task<int> GetCountFilteredAsync(FilterParametersDto filterParameters);

    Task<string> RemoveRoleFromUserAsync(string userId, UserRoles role);

    Task<string> ToggleBanUserAsync(string userId);

    Task<string> ToggleMuteUserAsync(string userId);
}
