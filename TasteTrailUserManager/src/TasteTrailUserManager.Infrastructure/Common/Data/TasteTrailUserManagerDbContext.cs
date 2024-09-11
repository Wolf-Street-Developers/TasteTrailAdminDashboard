using Microsoft.EntityFrameworkCore;
using TasteTrailUserManager.Core.Roles.Configurations;
using TasteTrailUserManager.Core.Roles.Models;
using TasteTrailUserManager.Core.Users.Configurations;
using TasteTrailUserManager.Core.Users.Models;

namespace TasteTrailUserManager.Infrastructure.Common.Data;

public class TasteTrailUserManagerDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }

    public TasteTrailUserManagerDbContext(DbContextOptions options) : base(options)
    {}
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new RoleConfiguration());
    }
}
