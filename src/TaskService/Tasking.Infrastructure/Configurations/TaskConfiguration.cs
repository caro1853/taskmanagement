using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tasking.Domain.Entities;

namespace Tasking.Infrastructure.Configurations
{
	public class TaskConfiguration: IEntityTypeConfiguration<TaskEntity>
	{
        public void Configure(EntityTypeBuilder<TaskEntity> builder)
        {
            builder.Property(o => o.Name)
                .IsRequired()
                .HasMaxLength(100);

           
                
                
        }
    }
}

