// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using Microsoft.AspNetCore.Identity;
// using TasteTrailData.Core.Filters.Specifications;
// using TasteTrailData.Core.Roles.Enums;
// using TasteTrailData.Infrastructure.Filters.Dtos;
// using TasteTrailUserManager.Core.Common.Admin.Services;
// using TasteTrailUserManager.Core.Roles.Services;
// using TasteTrailUserManager.Core.Users.Dtos;
// using TasteTrailUserManager.Core.Users.Models;
// using TasteTrailUserManager.Core.Users.Services;
// using TasteTrailUserManager.Infrastructure.Common.Admin.Factories;
// using System.Data;
// using Microsoft.EntityFrameworkCore;

// namespace TasteTrailUserManager.Infrastructure.Common.Admin.Services;


// public class AdminService : IAdminService
// {
//     private readonly IUserService _userService;
//     private readonly IRoleService _roleService;


//     public AdminService(IUserService userService, IRoleService roleService)
//     {
//         _userService = userService;
//         _roleService = roleService;
//     }

//     public Task<string> AssignRoleToUserAsync(string userId, UserRoles role)
//     {
//         throw new NotImplementedException();
//     }

//     public Task<int> GetCountFilteredAsync(FilterParametersDto filterParameters)
//     {
//         throw new NotImplementedException();
//     }

//     public Task<string> GetRoleByUsernameAsync(string username)
//     {
//         throw new NotImplementedException();
//     }

//     public Task<User> GetUserByIdAsync(string userId)
//     {
//         throw new NotImplementedException();
//     }

//     public Task<User> GetUserByUsernameAsync(string username)
//     {
//         throw new NotImplementedException();
//     }

//     public Task<FilterResponseDto<UserResponseDto>> GetUsersFiltereBySearchdAsync(FilterParametersSearchDto filterParameters)
//     {
//         throw new NotImplementedException();
//     }

//     public Task<string> RemoveRoleFromUserAsync(string userId, UserRoles role)
//     {
//         throw new NotImplementedException();
//     }

//     public async Task<string> ToggleBanUserAsync(string userId)
//     {
//         var user = await _userService.GetUserByIdAsync(userId);

//         if (user is null)
//             throw new ArgumentException("User not found!");

//         user.IsBanned = !user.IsBanned;
//         return await _userService.UpdateUserAsync(user);
//     }

//     public async Task<string> ToggleMuteUserAsync(string userId)
//     {
//         var user = await _userService.GetUserByIdAsync(userId) ?? throw new ArgumentException($"cannot find user with id: {userId}");

//         user.IsMuted = !user.IsMuted;
//         var result = await _userService.UpdateUserAsync(user);

//         return result;
//     }
// }