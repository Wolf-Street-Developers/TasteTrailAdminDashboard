using TasteTrailData.Core.Common.Repositories.Base;
using TasteTrailData.Core.Roles.Enums;
using TasteTrailAdminDashboard.Core.Users.Models;

namespace TasteTrailAdminDashboard.Core.Users.Repositories;

public interface IUserRepository : ICreateAsync<User, int>, IGetByIdAsync<User, string>, 
    IPutAsync<User, int>, IDeleteByIdAsync<string, int>
{
    Task<IQueryable<User>> GetAllQueryable();

    Task<User?> GetUserByUsernameAsync(string username);

    Task<User?> GetUserByEmailAsync(string email);
}
