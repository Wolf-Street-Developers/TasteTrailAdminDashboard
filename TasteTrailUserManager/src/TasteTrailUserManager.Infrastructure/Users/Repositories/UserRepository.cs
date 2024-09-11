#pragma warning disable CS1998


namespace TasteTrailUserManager.Infrastructure.Users.Repositories;

using TasteTrailUserManager.Core.Users.Models;
using TasteTrailUserManager.Core.Users.Repositories;
using TasteTrailUserManager.Infrastructure.Common.Data;

public class UserRepository : IUserRepository
{
    private readonly TasteTrailUserManagerDbContext _context;
    public UserRepository(TasteTrailUserManagerDbContext context)
    {
        _context = context;
    }

    public async Task<int> CreateAsync(User entity)
    {
        await _context.Users.AddAsync(entity);
        return await _context.SaveChangesAsync();
    }

    public async Task<int> DeleteByIdAsync(string id)
    {
        var userToDelete = _context.Users.Where(u => u.Id == id).First();
        _context.Users.Remove(userToDelete);

        return await _context.SaveChangesAsync();
    }

    public async Task<IQueryable<User>> GetAllQueryable()
    {
        return _context.Users.AsQueryable();
    }

    public async Task<User?> GetByIdAsync(string id)
    {
        return _context.Users.Where(u => u.Id == id).FirstOrDefault();
    }

    public Task<User?> GetUserByEmailAsync(string email)
    {
        throw new NotImplementedException();
    }

    public async Task<User?> GetUserByUsernameAsync(string username)
    {
        return _context.Users.Where(u => u.UserName == username).FirstOrDefault();
    }

    public async Task<int> PutAsync(User entity)
    {
        _context.Users.Update(entity);
        return await _context.SaveChangesAsync();
    }
}
