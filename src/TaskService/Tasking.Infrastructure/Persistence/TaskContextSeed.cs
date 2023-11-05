using System;
using Microsoft.Extensions.Logging;
using Tasking.Domain.Entities;

namespace Tasking.Infrastructure.Persistence
{
	public class TaskContextSeed
	{
		public static async Task SeedAsync(TaskContext taskContext, ILogger<TaskContextSeed> logger)
		{
            if (!taskContext.Tasks.Any() && !taskContext.Categories.Any())
            {
                taskContext.Tasks.AddRange(GetPreconfiguredTasks());
                taskContext.Categories.AddRange(GetPreconfiguredCategories());
                await taskContext.SaveChangesAsync();
                logger?.LogInformation("Seed database associated with context {DbContextName}", typeof(TaskContext).Name);
            }
        }

        private static IEnumerable<TaskEntity> GetPreconfiguredTasks()
        {
            var listTasks = new List<TaskEntity>();

            for (int i = 1; i <= 5; i++)
            {
                listTasks.Add(new TaskEntity() { Name = $"Task {i}", UserId = 58 });
            }

            return listTasks;
        }

        private static IEnumerable<CategoryEntity> GetPreconfiguredCategories()
        {
            var categories = new List<CategoryEntity>();

            categories.Add(new CategoryEntity { Name = "Analysis" });
            categories.Add(new CategoryEntity { Name = "Design" });
            categories.Add(new CategoryEntity { Name = "Development" });
            categories.Add(new CategoryEntity { Name = "Implementation" });
            categories.Add(new CategoryEntity { Name = "Quality" });

            return categories;
        }

    }
}

