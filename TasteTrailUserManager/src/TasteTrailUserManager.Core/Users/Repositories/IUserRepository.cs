using TasteTrailData.Core.Common.Repositories.Base;
using TasteTrailUserManager.Core.Users.Models;

namespace TasteTrailUserManager.Core.Users.Repositories;

public interface IUserRepository : ICreateAsync<User, string>, IGetByIdAsync<User, string>, 
    IPutAsync<User, string>, IDeleteByIdAsync<string, string>
{

    Task<IList<string>> GetRolesByUsernameAsync(string username);

    Task<IList<string>> GetRolesByEmailAsync(string email);

    Task<User> GetUserByUsernameAsync(string username);

    Task<User> GetUserByEmailAsync(string email);

    Task<bool> HasRegisteredUsers();

    Task PatchAvatarUrlPathAsync(string userId, string avatarUrl); 
}
