using System;
using Tasking.Application.Contracts.Persistence;
using Tasking.Domain.Entities;
namespace Tasking.Application.Contracts.Persistence
{
	public interface ITaskRepository : IAsyncRepository<TaskEntity>
    {
        Task<IEnumerable<TaskEntity>> GetTaskListByUser(int userid);
        Task<IEnumerable<TaskEntity>> GetTaskListByUserByCategory(int userid, int categoryid);
        Task<TaskEntity> GetTaskById(int taskid);
    }
}

