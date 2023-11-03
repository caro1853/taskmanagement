using System;
using Microsoft.EntityFrameworkCore;
using Tasking.Application.Contracts.Persistence;
using Tasking.Domain.Entities;
using Tasking.Infrastructure.Persistence;

namespace Tasking.Infrastructure.Repositories
{
    public class TaskRepository : RepositoryBase<TaskEntity>, ITaskRepository
    {
        public TaskRepository(TaskContext dbContext) : base(dbContext)
        {
        }
        public async Task<IEnumerable<TaskEntity>> GetTaskListByOwner(string ownerName)
        {
            var taskListByOwner = await _dbContext.Tasks
                                        .Where(p => p.UserId == 1)//TODO
                                        .ToListAsync();
            return taskListByOwner;
        }
    }
}

