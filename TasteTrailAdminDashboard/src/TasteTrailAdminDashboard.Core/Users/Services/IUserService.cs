
using TasteTrailAdminDashboard.Core.Users.Models;

namespace TasteTrailAdminDashboard.Core.Users.Services;

public interface IUserService
{
    Task AssignRoleAsync(string userId, string roleId);

    Task<IQueryable<User>> GetAllUsersQueryable();

    Task RemoveFromRoleAsync(string userId, string roleId, string defaultRoleId);

    Task CreateUserAsync(User user);
    
    Task<User> GetUserByIdAsync(string userId);

    Task<User> GetUserByUsernameAsync(string username);

    Task<User> GetUserByEmailAsync(string email);

    Task UpdateUserAsync(User user);

    Task DeleteUserAsync(string userId);

    Task<bool> HasRegisteredUsers(User user);
}
