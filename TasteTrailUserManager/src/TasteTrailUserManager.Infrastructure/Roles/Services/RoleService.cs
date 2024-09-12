
using TasteTrailData.Core.Roles.Enums;
using TasteTrailUserManager.Core.Roles.Models;
using TasteTrailUserManager.Core.Roles.Repositories;
using TasteTrailUserManager.Core.Roles.Services;

namespace TasteTrailUserManager.Infrastructure.Roles.Services;

public class RoleService : IRoleService
{
    private readonly IRoleRepository _repository;

    public RoleService(IRoleRepository repository)
    {
        _repository = repository;
    }

    public async Task CreateRoleAsync(UserRoles role)
    {
        var roleToCreate = new Role()
        {
            Name = role.ToString()
        };

        if(await _repository.CreateAsync(roleToCreate) == 0)
        {
            throw new Exception($"couldn't create role {role}");
        }
    }

    public async Task DeleteRoleAsync(UserRoles role)
    {
        var roleToDelete = await _repository.GetByNameAsync(role) ?? throw new ArgumentException($"role {role} doesn't exists");

        if(await _repository.DeleteByIdAsync(roleToDelete.Id) == 0)
        {
            throw new Exception($"couldn't delete role {role}");
        }
    }

    public async Task<Role> GetByNameAsync(UserRoles userRole)
    {
        return await _repository.GetByNameAsync(userRole) ?? throw new ArgumentException($"role: {userRole} doesn't exists");;
    }

    public async Task<Role> GetRoleAsNoTrackingAsync(string id)
    {
        if(string.IsNullOrEmpty(id) || string.IsNullOrWhiteSpace(id))
        {
            throw new ArgumentException("id is empty");
        }

        return await _repository.GetAsNoTrackingAsync(id) ?? throw new ArgumentException($"role with id: {id} doesn't exists");;
    }

    public async Task<Role> GetRoleByIdAsync(string id)
    {
        if(string.IsNullOrEmpty(id) || string.IsNullOrWhiteSpace(id))
        {
            throw new ArgumentException("id is empty");
        }

        return await _repository.GetByIdAsync(id) ?? throw new ArgumentException($"role with id: {id} doesn't exists");
    }

    public async Task<bool> RoleExistsAsync(UserRoles role)
    {
        return await _repository.RoleExistsAsync(role);
    }

    public async Task SetupRolesAsync()
    {
        await _repository.SetupRolesAsync();
    }
}
