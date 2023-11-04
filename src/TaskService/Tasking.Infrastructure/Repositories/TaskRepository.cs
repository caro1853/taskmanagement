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
        public async Task<IEnumerable<TaskEntity>> GetTaskListByUser(int userid)
        {
            var taskListByOwner = await _dbContext.Tasks
                                        .Where(p => p.UserId == userid)
                                        .Include("Category")
                                        .ToListAsync();
            return taskListByOwner;
        }

        public async Task<IEnumerable<TaskEntity>> GetTaskListByUserByCategory(int userid, int categoryid)
        {
            var tasks = await _dbContext.Tasks
                                        .Where(p => p.UserId == userid
                                                && (p.Category == null ? false : p.Category.Id == categoryid)
                                              )
                                        .Include("Category")
                                        .ToListAsync();
            return tasks;
        }

        public async Task<TaskEntity> GetTaskById(int taskid)
        {
            var taskById = await _dbContext.Tasks
                                        .Where(p => p.Id == taskid)
                                        .Include("Category")
                                        .FirstOrDefaultAsync();
            return taskById;
        }
    }
}

