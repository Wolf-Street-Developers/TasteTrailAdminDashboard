using Microsoft.EntityFrameworkCore;
using TasteTrailAdminDashboard.Core.Roles.Configurations;
using TasteTrailAdminDashboard.Core.Roles.Models;
using TasteTrailAdminDashboard.Core.Users.Configurations;
using TasteTrailAdminDashboard.Core.Users.Models;

namespace TasteTrailAdminDashboard.Infrastructure.Common.Data;

public class TasteTrailAdminDashboardDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }

    public TasteTrailAdminDashboardDbContext(DbContextOptions options) : base(options)
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
