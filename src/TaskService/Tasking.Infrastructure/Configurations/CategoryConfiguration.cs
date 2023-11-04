using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tasking.Domain.Entities;

namespace Tasking.Infrastructure.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<CategoryEntity>
    {
        public void Configure(EntityTypeBuilder<CategoryEntity> builder)
        {
            builder.Property(o => o.CreatedBy)
                .HasMaxLength(100);

            builder.Property(o => o.LastModifiedBy)
                .HasMaxLength(100);

            builder.Property(o => o.Name)
                .IsRequired()
                .HasMaxLength(30);
        }
    }
}

