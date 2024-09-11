using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using TasteTrailData.Core.Filters.Specifications;
using TasteTrailData.Core.Roles.Enums;
using TasteTrailData.Infrastructure.Filters.Dtos;
using TasteTrailUserManager.Core.Common.Admin.Services;
using TasteTrailUserManager.Core.Roles.Services;
using TasteTrailUserManager.Core.Users.Dtos;
using TasteTrailUserManager.Core.Users.Models;
using TasteTrailUserManager.Core.Users.Services;
using TasteTrailUserManager.Infrastructure.Common.Admin.Factories;
using System.Data;
using Microsoft.EntityFrameworkCore;

namespace TasteTrailUserManager.Infrastructure.Common.Admin.Services;


public class AdminService : IAdminService
{
    private readonly IUserService _userService;
    private readonly IRoleService _roleService;


    public AdminService(IUserService userService, IRoleService roleService)
    {
        _userService = userService;
        _roleService = roleService;
    }

    public async Task AssignRoleToUserAsync(string userId, UserRoles role)
    {
        var foundRole = await _roleService.GetByNameAsync(role);

        var isExists = await _roleService.RoleExistsAsync(role);
        if(isExists)
        {
            throw new Exception($"role: {role} doesn't exists");
        }

        await _userService.AssignRoleAsync(userId, foundRole.Id);
    }

    public async Task<int> GetCountFilteredAsync(FilterParametersDto filterParameters)
    {
        var newFilterParameters = new FilterParameters<User>() {
            PageNumber = filterParameters.PageNumber,
            PageSize = filterParameters.PageSize,
            Specification = UserManipulationsFilterFactory.CreateFilter(filterParameters.Type),
            SearchTerm = null
        };

        var query = await _userService.GetAllUsersQueryable();

        if (filterParameters is null)
            return await query.CountAsync();

        if (newFilterParameters.Specification != null)
            query = newFilterParameters.Specification.Apply(query);

        return await query.CountAsync();
    }

    public async Task<string> GetRoleByUsernameAsync(string username)
    {
        var foundUser = await _userService.GetUserByUsernameAsync(username) ?? throw new ArgumentException($"user with name: {username} doesn't exists");
        var userRole = await _roleService.GetRoleByIdAsync(foundUser.RoleId);

        return userRole.Name;
    }

    public async Task<User> GetUserByIdAsync(string userId)
    {
        return await _userService.GetUserByIdAsync(userId);
    }

    public async Task<User> GetUserByUsernameAsync(string username)
    {
        return await _userService.GetUserByUsernameAsync(username);
    }

    public async Task<FilterResponseDto<UserResponseDto>> GetUsersFiltereBySearchdAsync(FilterParametersSearchDto filterParameters)
    {
        if(filterParameters.PageSize <= 0 || filterParameters.PageNumber <= 0)
        {
            throw new ArgumentException("pagesize and pagenumber are irrelevant");
        }
        
        var newFilterParameters = new FilterParameters<User>() {
            PageNumber = filterParameters.PageNumber,
            PageSize = filterParameters.PageSize,
            Specification = UserManipulationsFilterFactory.CreateFilter(filterParameters.Type),
            SearchTerm = filterParameters.SearchTerm
        };

        var users = await _userService.GetAllUsersQueryable();

        var totalUsers = await users.CountAsync();

        if(newFilterParameters.Specification != null)
        {
            users = newFilterParameters.Specification.Apply(users);
            totalUsers = await users.CountAsync();
        }

        var searchedUsers = new List<User>(users);

        if (filterParameters.SearchTerm is not null)
        {
            var searchTerm = $"%{filterParameters.SearchTerm.ToLower()}%";

            searchedUsers = users.Where(f =>
                f.UserName != null && EF.Functions.Like(f.UserName.ToLower(), searchTerm)
            ).ToList();

            totalUsers = searchedUsers.Count;
        }

        var totalPages = (int)Math.Ceiling(totalUsers / (double)filterParameters.PageSize);

        var userDtos = new List<UserResponseDto>();

        var paginatedUsers = searchedUsers.Skip((filterParameters.PageNumber - 1) * filterParameters.PageSize).Take(filterParameters.PageSize);

        foreach (var user in paginatedUsers)
        {
            var role = await _roleService.GetRoleByIdAsync(user.RoleId);
            var userDto = new UserResponseDto
            {
                User = user,
                Role = role.Name
            };

            userDtos.Add(userDto);
        }

        var filterReponse = new FilterResponseDto<UserResponseDto>() {
            CurrentPage = filterParameters.PageNumber,
            AmountOfPages = totalPages,
            AmountOfEntities = totalUsers,
            Entities = userDtos
        };

        return filterReponse;
    }

    public async Task RemoveRoleFromUserAsync(string userId, UserRoles role)
    {
        var roleToDelete = await _roleService.GetByNameAsync(role);
        var userRole = await _roleService.GetByNameAsync(UserRoles.User);

        await _userService.RemoveFromRoleAsync(userId: userId, roleId: roleToDelete.Id, defaultRoleId: userRole.Id);
    }

    public async Task ToggleBanUserAsync(string userId)
    {
        var user = await _userService.GetUserByIdAsync(userId);

        if (user is null)
            throw new ArgumentException("User not found!");

        user.IsBanned = !user.IsBanned;
        await _userService.UpdateUserAsync(user);
    }

    public async Task ToggleMuteUserAsync(string userId)
    {
        var user = await _userService.GetUserByIdAsync(userId) ?? throw new ArgumentException($"cannot find user with id: {userId}");

        user.IsMuted = !user.IsMuted;
        await _userService.UpdateUserAsync(user);
    }
}