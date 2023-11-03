using System;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Tasking.Domain.Common;
using Tasking.Domain.Entities;

namespace Tasking.Infrastructure.Persistence
{
	public class TaskContext: DbContext
	{
		public TaskContext(DbContextOptions<TaskContext> options) : base(options)
        {
		}

		public DbSet<TaskEntity> Tasks { get; set; }
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<CategoryEntity> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(
                Assembly.GetExecutingAssembly());
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<BaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.Now;
                        entry.Entity.CreatedBy = "ccv";
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedDate = DateTime.Now;
                        entry.Entity.LastModifiedBy = "ccv";
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}

