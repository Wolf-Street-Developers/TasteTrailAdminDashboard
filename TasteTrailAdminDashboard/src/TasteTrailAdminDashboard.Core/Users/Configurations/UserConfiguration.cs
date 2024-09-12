using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TasteTrailAdminDashboard.Core.Users.Models;

namespace TasteTrailAdminDashboard.Core.Users.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {

        builder.HasKey(u => u.Id);

        builder.Property(u => u.IsBanned)
            .IsRequired();

        builder.Property(u => u.IsMuted)
            .IsRequired();

        builder.Property(u => u.Email)
            .IsRequired();
        builder.HasIndex(u => u.Email)
            .IsUnique();

        builder.Property(u => u.UserName)
            .IsRequired();
        builder.HasIndex(u => u.UserName)
            .IsUnique();
    }
}
