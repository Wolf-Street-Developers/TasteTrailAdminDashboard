
using TasteTrailData.Core.Roles.Enums;
using TasteTrailAdminDashboard.Core.Users.Models;
using TasteTrailAdminDashboard.Core.Users.Repositories;
using TasteTrailAdminDashboard.Core.Users.Services;

namespace TasteTrailAdminDashboard.Infrastructure.Users.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task AssignRoleAsync(string userId, string roleId)
    {
        if(string.IsNullOrEmpty(userId) || string.IsNullOrWhiteSpace(userId))
        {
            throw new ArgumentException("userId is empty");
        }

        if(string.IsNullOrEmpty(roleId) || string.IsNullOrWhiteSpace(roleId))
        {
            throw new ArgumentException("roleId is empty");
        }

        var user = await _userRepository.GetByIdAsync(userId) ?? throw new ArgumentException($"cannot find user with id: {userId}");

        if(user.RoleId == roleId)
        {
            throw new ArgumentException("user already in role!");
        }
        user.RoleId = roleId;

        var changedRows = await _userRepository.PutAsync(user);

        if(changedRows == 0)
        {
            throw new Exception($"user has not been assigned to role {UserRoles.User}");
        }
    }

    public async Task CreateUserAsync(User user)
    {
        if(user is null || user.Email is null || user.UserName is null || user.RoleId is null)
        {
            throw new ArgumentException("user is empty or user params are empty");
        }

        var changedRows = await _userRepository.CreateAsync(user);

        if(changedRows == 0)
        {
            throw new Exception("user has not been created");
        }
    }

    public async Task DeleteUserAsync(string userId)
    {
        var changedRows = await _userRepository.DeleteByIdAsync(userId);

        if(changedRows == 0)
        {
            throw new Exception("user has not been deleted");
        }
    }

    public async Task<IQueryable<User>> GetAllUsersQueryable()
    {
        return await _userRepository.GetAllQueryable();
    }


    public async Task<User> GetUserByEmailAsync(string email)
    {
        if(string.IsNullOrEmpty(email) || string.IsNullOrWhiteSpace(email))
        {
            throw new ArgumentException("email is empty");
        }

        var user = await _userRepository.GetUserByEmailAsync(email) ?? throw new ArgumentException($"couldn't find user with email: {email}");

        return user;
    }

    public async Task<User> GetUserByIdAsync(string userId)
    {
        if(string.IsNullOrEmpty(userId) || string.IsNullOrWhiteSpace(userId))
        {
            throw new ArgumentException("userId is empty");
        }

        var user = await _userRepository.GetByIdAsync(userId) ?? throw new ArgumentException($"couldn't find user with userId: {userId}");

        return user;
    }

    public async Task<User> GetUserByUsernameAsync(string username)
    {
        if(string.IsNullOrEmpty(username) || string.IsNullOrWhiteSpace(username))
        {
            throw new ArgumentException("username is empty");
        }

        var user = await _userRepository.GetUserByUsernameAsync(username) ?? throw new ArgumentException($"couldn't find user with name: {username}");

        return user;
    }

    public async Task<bool> HasRegisteredUsers(User user)
    {
        if(user is null || user.Id is null)
        {
            throw new ArgumentException("user is empty");
        }

        return await _userRepository.GetByIdAsync(user.Id) is not null;
    }


    public async Task RemoveFromRoleAsync(string userId, string roleId, string defaultRoleId)
    {
        if(string.IsNullOrEmpty(userId) || string.IsNullOrWhiteSpace(userId))
        {
            throw new ArgumentException("userId is empty");
        }

        if(string.IsNullOrEmpty(roleId) || string.IsNullOrWhiteSpace(roleId))
        {
            throw new ArgumentException("roleId is empty");
        }

        var user = await _userRepository.GetByIdAsync(userId) ?? throw new ArgumentException($"cannot find user with id: {userId}");

        if(user.RoleId != roleId)
        {
            throw new ArgumentException($"user is not assigned to role with id: {roleId}");
        }

        user.RoleId = defaultRoleId;

        var changedRows = await _userRepository.PutAsync(user);

        if(changedRows == 0)
        {
            throw new Exception($"user has not been assigned to role {UserRoles.User}");
        }
    }

    public async Task UpdateUserAsync(User user)
    {

        if(user is null || user.Id is null)
        {
            throw new ArgumentException("user or userId are empty");
        }

        var foundUser = await _userRepository.GetByIdAsync(user.Id) ?? throw new ArgumentException($"there is no user with id: {user.Id}");
        foundUser.Email = user.Email is null ? foundUser.Email : user.Email; 
        foundUser.UserName = user.UserName is null ? foundUser.UserName : user.UserName;

        System.Console.WriteLine($"\n\n\n\n\n\n\n\n\n  {foundUser.Id}   {foundUser.RoleId}   {foundUser.Email}    {foundUser.UserName}   \n\n\n\n\n\n\n\n\n\n");

        var changedRows = await _userRepository.PutAsync(foundUser);

        if(changedRows == 0)
        {
            throw new Exception($"user has not been changed");
        }
    }
}
