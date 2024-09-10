

using TasteTrailData.Core.Roles.Enums;
using TasteTrailUserManager.Core.Users.Models;

namespace TasteTrailUserManager.Core.Users.Services;

public interface IUserService
{
    Task AddToRoleAsync(User user, string roleId);

    Task<IQueryable<User>> GetAllUsersQueryable();

    Task RemoveFromRoleAsync(User user, string roleId);

    Task CreateUserAsync(User user);

    Task<string> GetRoleByUsernameAsync(string username);

    Task<string> GetRoleByEmailAsync(string email);

    Task<User?> GetUserByIdAsync(string userId);

    Task<User?> GetUserByUsernameAsync(string username);

    Task<User?> GetUserByEmailAsync(string email);

    Task UpdateUserAsync(User user);

    Task DeleteUserAsync(string userId);

    Task<bool> HasRegisteredUsers(User user);

    Task PatchAvatarUrlPathAsync(string userId, string avatarUrl); 
}
