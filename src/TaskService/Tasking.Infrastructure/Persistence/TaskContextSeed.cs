using System;
using Microsoft.Extensions.Logging;
using Tasking.Domain.Entities;

namespace Tasking.Infrastructure.Persistence
{
	public class TaskContextSeed
	{
		public static async Task SeedAsync(TaskContext taskContext, ILogger<TaskContextSeed> logger)
		{
            if (!taskContext.Tasks.Any())
            {
                taskContext.Tasks.AddRange(GetPreconfiguredTasks());
                await taskContext.SaveChangesAsync();
                logger?.LogInformation("Seed database associated with context {DbContextName}", typeof(TaskContext).Name);
            }
        }

        private static IEnumerable<TaskEntity> GetPreconfiguredTasks()
        {
            var listTasks = new List<TaskEntity>();

            listTasks.Add(
                new TaskEntity()
                {
                    Name = "Create Design"
                }
                );

            return listTasks;
        }
	}
}

