
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TasteTrailAdminDashboard.Core.Roles.Models;

namespace TasteTrailAdminDashboard.Core.Roles.Configurations;


public class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {

        builder.HasKey(u => u.Id);

        builder
            .Property(u => u.Id)
            .ValueGeneratedNever(); 

        builder.Property(u => u.Name)
            .IsRequired();

        builder.HasIndex(u => u.Name)
            .IsUnique();

        builder.HasMany(u => u.Users)
            .WithOne()
            .HasForeignKey(r => r.RoleId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}