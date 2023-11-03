using System;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Tasking.Domain.Entities;

namespace Tasking.Infrastructure.Persistence
{
	public class TaskContextDev : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=127.0.0.1;Database=TaskDb;User Id=sa;Password=Caro123456;TrustServerCertificate=true");
        }

        public DbSet<TaskEntity> Tasks { get; set; }
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<CategoryEntity> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(
                Assembly.GetExecutingAssembly());
        }
    }
}

