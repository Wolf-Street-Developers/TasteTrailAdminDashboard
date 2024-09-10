using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TasteTrailUserManager.Core.Roles.Models;

namespace TasteTrailUserManager.Core.Roles.Configurations;


public class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {

        builder.HasKey(u => u.Id);

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