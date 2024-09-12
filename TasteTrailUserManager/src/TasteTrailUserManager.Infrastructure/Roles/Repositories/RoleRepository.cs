#pragma warning disable CS1998

namespace TasteTrailUserManager.Infrastructure.Roles.Repositories;

using Microsoft.EntityFrameworkCore;
using TasteTrailData.Core.Roles.Enums;
using TasteTrailUserManager.Core.Roles.Models;
using TasteTrailUserManager.Core.Roles.Repositories;
using TasteTrailUserManager.Infrastructure.Common.Data;

public class RoleRepository : IRoleRepository
{
    private readonly TasteTrailUserManagerDbContext _context;

    public RoleRepository(TasteTrailUserManagerDbContext context)
    {
        _context = context;
    }

    public async Task<int> CreateAsync(Role entity)
    {
        await _context.Roles.AddAsync(entity);
        return await _context.SaveChangesAsync();
    }

    public async Task<int> DeleteByIdAsync(string id)
    {
        var roleToDelete = _context.Roles.Where(role => role.Id == id).First();
        _context.Roles.Remove(roleToDelete);

        return await _context.SaveChangesAsync();
    }

    public async Task<Role?> GetAsNoTrackingAsync(string id)
    {
        return _context.Roles.Where(role => role.Id == id).AsNoTracking().FirstOrDefault();
    }

    public async Task<Role?> GetByIdAsync(string id)
    {
        return _context.Roles.Where(role => role.Id == id).FirstOrDefault();
    }

    public async Task<Role?> GetByNameAsync(UserRoles userRole)
    {
        return _context.Roles.Where(role => role.Name == userRole.ToString()).FirstOrDefault();
    }

    public async Task<bool> RoleExistsAsync(UserRoles userRole)
    {
        return _context.Roles.Where(role => role.Name == userRole.ToString()).FirstOrDefault() is not null; 
    }

    public async Task<int> SetupRolesAsync()
    {
        List<Role> roles = [
            new Role(){ 
                Id = $"{Guid.NewGuid()}",
                Name = $"{UserRoles.Admin}"
                }, 
            new Role(){ 
                Id = $"{Guid.NewGuid()}",
                Name = $"{UserRoles.User}"
                }, 
            new Role(){ 
                Id = $"{Guid.NewGuid()}",
                Name = $"{UserRoles.Owner}"
            } ];

        foreach(var role in roles)
        {
            var isExists = _context.Roles.Where(r => r.Name == role.Name).FirstOrDefault() is not null;

            if(!isExists)
            {
                await _context.Roles.AddAsync(role);
            }
        }

        return await _context.SaveChangesAsync();
    }
}
