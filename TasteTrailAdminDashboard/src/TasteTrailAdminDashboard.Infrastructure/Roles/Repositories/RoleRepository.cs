#pragma warning disable CS1998

namespace TasteTrailAdminDashboard.Infrastructure.Roles.Repositories;

using Microsoft.EntityFrameworkCore;
using TasteTrailData.Core.Roles.Enums;
using TasteTrailAdminDashboard.Core.Roles.Models;
using TasteTrailAdminDashboard.Core.Roles.Repositories;
using TasteTrailAdminDashboard.Infrastructure.Common.Data;

public class RoleRepository : IRoleRepository
{
    private readonly TasteTrailAdminDashboardDbContext _context;

    public RoleRepository(TasteTrailAdminDashboardDbContext context)
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

    public async Task<int> PutAsync(Role entity)
    {
        var toChange = await _context.Roles.Where(r => r.Name == entity.Name).FirstOrDefaultAsync() 
            ?? throw new ArgumentException($"role {entity.Name} doen't exists");
        toChange.Id = entity.Id;

        _context.Roles.Remove(toChange);
        await _context.Roles.AddAsync(entity);

        return await _context.SaveChangesAsync();
    }

    public async Task<bool> RoleExistsAsync(UserRoles userRole)
    {
        System.Console.WriteLine(_context.Roles.Count());
        return _context.Roles.Where(role => role.Name == userRole.ToString()).FirstOrDefault() is not null; 
    }

    public async Task<int> SetupRolesAsync()
    {
        

        List<UserRoles> roleNames = [UserRoles.Admin, UserRoles.User, UserRoles.Owner];
        List<string> ids = ["57082502-2ccf-4610-b865-fdd780b8bf1d", "6424977e-131b-4f9f-aa3f-9626dd293021", "c0d1b7c6-a250-4a02-a0c8-a8896de8140e"];
        
        

        for (int i = 0; i < roleNames.Count; i++)
        {
            var roleExists = await this.RoleExistsAsync(roleNames[i]);

            if (!roleExists)
            {
                var role = new Role()
                {
                    Id = ids[i],
                    Name = roleNames[i].ToString()
                };
                var result = await this.CreateAsync(role);
                
                if (result == 0)
                    throw new Exception("cannot create roles!!");
        
            }
        }

        return 3;
    }
}
