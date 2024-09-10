

using TasteTrailUserManager.Core.Users.Models;

namespace TasteTrailUserManager.Core.Users.Services;

public interface IUserService
{
    Task<string> CreateUserAsync(User user);

    Task<IList<string>> GetRolesByUsernameAsync(string username);

    Task<IList<string>> GetRolesByEmailAsync(string email);

    Task<User?> GetUserByIdAsync(string userId);

    Task<User> GetUserByUsernameAsync(string username);

    Task<User> GetUserByEmailAsync(string email);

    Task<string> UpdateUserAsync(User user, string senderId);

    Task<string> DeleteUserAsync(string userId);

    Task<bool> HasRegisteredUsers();

    Task PatchAvatarUrlPathAsync(string userId, string avatarUrl); 
}
