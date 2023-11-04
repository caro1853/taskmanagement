using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tasking.Domain.Entities;

namespace Tasking.Infrastructure.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.Property(o => o.CreatedBy)
                .HasMaxLength(100);

            builder.Property(o => o.LastModifiedBy)
                .HasMaxLength(100);

            builder.Property(o => o.Name)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}

